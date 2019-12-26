using System;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Computer
{
    public partial class MainForm : Form
    {
        #region 成员变量 私有寄存器
        /// <summary>
        /// 程序计数器
        /// </summary>
        private int pc;

        /// <summary>
        /// 总线
        /// </summary>
        private int bus;

        /// <summary>
        /// 指令寄存器
        /// </summary>
        private int ir;

        /// <summary>
        /// 源操作数寄存器
        /// </summary>
        private int rr;

        /// <summary>
        /// 目的操作数寄存器
        /// </summary>
        private int rd;

        /// <summary>
        /// 临时寄存器
        /// </summary>
        private int temp;

        /// <summary>
        /// alu的输入端
        /// </summary>
        private int la;

        /// <summary>
        /// alu的输出端
        /// </summary>
        private int lt;

        /// <summary>
        /// 指令存储器的地址寄存器
        /// </summary>
        private int imar;

        /// <summary>
        /// 指令存储器的数据寄存器
        /// </summary>
        private int imdr;

        /// <summary>
        /// 状态寄存器
        /// </summary>
        private byte[] sr = new byte[8];
        /// <summary>
        /// 状态寄存器每个位的名称
        /// </summary>
        private enum srNames
        {
            C, Z, N, V, S, H, T, I
        };
        #endregion

        #region 成员变量 指令存储器和通用寄存器
        /// <summary>
        /// 当前正在执行的指令
        /// </summary>
        private Instruction currentInstruction;
        /// <summary>
        /// 存储所有指令的列表
        /// </summary>
        private List<Instruction> instructions = new List<Instruction>();

        /// <summary>
        /// 通用寄存器的值数组，下标对应寄存器号
        /// </summary>
        private int[] registers = new int[16];
        /// <summary>
        /// 通用寄存器的所有名称
        /// </summary>
        private string[] registerNames = {
            "R0",
            "R1",
            "R2",
            "R3",
            "R4",
            "R5",
            "R6",
            "R7",
            "R8",
            "R9",
            "R10",
            "R11",
            "R12",
            "R13",
            "R14",
            "R15",
        };
        #endregion

        #region 成员变量 微指令和微程序
        /// <summary>
        /// 所有的微指令
        /// </summary>
        private Dictionary<string, string> mCode = new Dictionary<string, string>();
        /// <summary>
        /// 所有指令的微程序
        /// </summary>
        private Dictionary<string, string[]> mProgram = new Dictionary<string, string[]>();

        /// <summary>
        /// 执行微程序的方法原型定义
        /// </summary>
        private delegate void mCodeRunnerDelegate();
        /// <summary>
        /// 执行微程序的方法定义
        /// </summary>
        private Dictionary<string, mCodeRunnerDelegate> mCodeRunner = new Dictionary<string, mCodeRunnerDelegate>();

        /// <summary>
        /// 当前将要执行的微指令的下标
        /// </summary>
        private int currentMCodeIndex = 0;
        /// <summary>
        /// 当前指令的微程序
        /// </summary>
        private List<string> currentMCodeList = new List<string>();
        #endregion

        #region 成员变量 机器周期
        /// <summary>
        /// 当前的机器周期
        /// </summary>
        private int currentCycle = 0;
        /// <summary>
        /// 所有的机器周期名字
        /// </summary>
        private string[] cycleNames =
        {
            "FT",
            "ST",
            "DT",
            "ET"
        };
        #endregion

        #region 成员变量 其他
        /// <summary>
        /// 当前应执行的指令下标
        /// </summary>
        private int currentInstructionIndex = 0;

        /// <summary>
        /// 表示当前正在自动执行每一条指令
        /// </summary>
        private bool running = false;
        /// <summary>
        /// 使用单独的线程来自动执行全部指令
        /// </summary>
        Thread worker;
        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            InitTextBoxs();
            InitListBoxSr();
            InitListBoxRegisters();
            InitListBoxCycle();
            InitMCode();
            InitMProgram();
            InitMCodeRunner();

            //指定不再捕获对错误线程的调用
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        #endregion

        #region 初始化方法 界面
        /// <summary>
        /// 初始化界面上的sr列表
        /// </summary>
        private void InitListBoxSr()
        {
            listBoxSr.Items.Clear();
            for (int i = 0; i < sr.Length; i++)
            {
                listBoxSr.Items.Add(string.Format("{0}: {1}", (srNames)i, sr[i]));
            }
        }

        /// <summary>
        /// 初始化界面上的通用寄存器列表
        /// </summary>
        private void InitListBoxRegisters()
        {
            listBoxRegisters.Items.Clear();
            for (int i = 0; i < registerNames.Length; i++)
            {
                listBoxRegisters.Items.Add(string.Format("{0,3}: 0x{1:x2}", registerNames[i], registers[i]));
            }
        }

        /// <summary>
        /// 初始化界面上所有的私有寄存器
        /// </summary>
        private void InitTextBoxs()
        {
            UpdateTextBoxRegisters();
        }

        /// <summary>
        /// 初始化界面上的指令列表
        /// 在导入文件后执行
        /// </summary>
        private void InitListBoxInstruction()
        {
            listBoxCode.Items.Clear();
            listBoxBCode.Items.Clear();

            for (int i = 0; i < instructions.Count; i++)
            {
                listBoxCode.Items.Add(string.Format("0x{0:x4}: {1}", i, instructions[i].code));
                listBoxBCode.Items.Add(string.Format("0x{0:x4}: {1}", i, ToBitString(instructions[i].bCode)));
            }
        }

        /// <summary>
        /// 初始化界面上的机器周期列表
        /// </summary>
        private void InitListBoxCycle()
        {
            listBoxCycle.Items.Clear();
            for (int i = 0; i < cycleNames.Length; i++)
            {
                listBoxCycle.Items.Add(cycleNames[i]);
            }
        }

        /// <summary>
        /// 初始化界面上的微指令列表
        /// 在开始执行一条指令的时候调用
        /// </summary>
        private void InitListBoxMCode()
        {
            listBoxMCode.Items.Clear();
            for (int i = 0; i < currentMCodeList.Count; i++)
            {
                listBoxMCode.Items.Add(mCode[currentMCodeList[i]]);
            }
        }
        #endregion

        #region 初始化方法 成员变量
        /// <summary>
        /// 初始化微指令
        /// </summary>
        private void InitMCode()
        {
            mCode.Add("A", "PC->BUS, BUS->IMAR, READ, CLEAR LA, 1->C0, ADD, ALU->LT");
            mCode.Add("B", "LT->BUS, BUS->PC, WAIT");
            mCode.Add("C", "IMDR->BUS, BUS->IR");
            mCode.Add("D", "PC-BUS, BUS->LA");
            mCode.Add("E", "TEMP->BUS, BUS->Rd");
            mCode.Add("F", "Rs->BUS, BUS->RR");
            mCode.Add("G", "TEMP->BUS, 1->C0, ADD, ALU->LT");
            mCode.Add("H", "Rd->BUS, BUS->RD");
            mCode.Add("M", "RD->BUS, BUS->LA");
            mCode.Add("I1", "RR->BUS, MUL");
            mCode.Add("I2", "RR->BUS, ADD, ALU->LT");
            mCode.Add("I3", "RR->BUS, SUB, ALU->LT");
            mCode.Add("L1", "ALU->LT, LT->BUS, BUS->Ra");
            mCode.Add("L2", "LT->BUS, BUS->Rd");
            mCode.Add("J", "RR->BUS, BUS->Rd");
            mCode.Add("K", "LT->BUS, BUS->PC");
            mCode.Add("V", "1->FT");
            mCode.Add("W", "1->ST");
            mCode.Add("X", "1->DT");
            mCode.Add("Y", "1->ET");
            mCode.Add("Z", "空操作");
        }

        /// <summary>
        /// 初始化每条指令的微程序
        /// </summary>
        private void InitMProgram()
        {
            mProgram.Add("ADD", new string[] { "A", "B", "C", "W", "F", "X", "H", "Y", "M", "I2", "L2", "V" });
            mProgram.Add("SUB", new string[] { "A", "B", "C", "W", "F", "X", "H", "Y", "M", "I3", "L2", "V" });
            mProgram.Add("MUL", new string[] { "A", "B", "C", "W", "F", "X", "H", "Y", "M", "I1", "Z", "Z", "L1", "V" });
            mProgram.Add("RJMP", new string[] { "A", "B", "C", "Y", "D", "G", "K", "V" });
            mProgram.Add("BRMI", new string[] { "A", "B", "C", "Y", "D", "G", "K", "V" });
            mProgram.Add("MOV", new string[] { "A", "B", "C", "W", "F", "Y", "J", "V" });
            mProgram.Add("LDI", new string[] { "A", "B", "C", "Y", "E", "V" });
            mProgram.Add("LD", new string[] { "A", "B", "C", "Y", "E", "J", "V" });
            mProgram.Add("ST", new string[] { "A", "B", "C", "Y", "E", "J", "V" });
            mProgram.Add("NOP", new string[] { "A", "B", "C", "V" });
        }

        private void InitMCodeRunner()
        {
            mCodeRunner.Add("A", new mCodeRunnerDelegate(RunnerA));
            mCodeRunner.Add("B", new mCodeRunnerDelegate(RunnerB));
            mCodeRunner.Add("C", new mCodeRunnerDelegate(RunnerC));
            mCodeRunner.Add("D", new mCodeRunnerDelegate(RunnerD));
            mCodeRunner.Add("E", new mCodeRunnerDelegate(RunnerE));
            mCodeRunner.Add("F", new mCodeRunnerDelegate(RunnerF));
            mCodeRunner.Add("G", new mCodeRunnerDelegate(RunnerG));
            mCodeRunner.Add("H", new mCodeRunnerDelegate(RunnerH));
            mCodeRunner.Add("J", new mCodeRunnerDelegate(RunnerJ));
            mCodeRunner.Add("K", new mCodeRunnerDelegate(RunnerK));
            mCodeRunner.Add("M", new mCodeRunnerDelegate(RunnerM));
            mCodeRunner.Add("V", new mCodeRunnerDelegate(RunnerV));
            mCodeRunner.Add("W", new mCodeRunnerDelegate(RunnerW));
            mCodeRunner.Add("X", new mCodeRunnerDelegate(RunnerX));
            mCodeRunner.Add("Y", new mCodeRunnerDelegate(RunnerY));
            mCodeRunner.Add("Z", new mCodeRunnerDelegate(RunnerZ));
            mCodeRunner.Add("I1", new mCodeRunnerDelegate(RunnerI1));
            mCodeRunner.Add("I2", new mCodeRunnerDelegate(RunnerI2));
            mCodeRunner.Add("I3", new mCodeRunnerDelegate(RunnerI3));
            mCodeRunner.Add("L1", new mCodeRunnerDelegate(RunnerL1));
            mCodeRunner.Add("L2", new mCodeRunnerDelegate(RunnerL2));
        }

        /// <summary>
        /// 初始化当前的微指令列表
        /// </summary>
        /// <param name="currentOp">当前的汇编指令OP字段</param>
        private void InitCurrentMProgram(string currentOp)
        {
            currentMCodeIndex = 0;
            currentMCodeList.Clear();
            string[] mp = mProgram[currentOp];
            for (int i = 0; i < mp.Length; i++)
            {
                currentMCodeList.Add(mp[i]);
            }
        }

        /// <summary>
        /// 还原所有的变量值
        /// </summary>
        private void InitAllVar()
        {
            pc = 0;
            bus = 0;
            ir = 0;
            rr = 0;
            rd = 0;
            temp = 0;
            la = 0;
            lt = 0;
            imar = 0;
            imdr = 0;
            sr = new byte[8];
            registers = new int[16];

            currentInstruction = null;
            currentInstructionIndex = 0;
            currentMCodeIndex = 0;
            currentMCodeList.Clear();
            currentCycle = 0;
        }
        #endregion

        #region 界面更新方法
        /// <summary>
        /// 更新界面上的所有私有寄存器
        /// </summary>
        private void UpdateTextBoxRegisters()
        {
            textBoxPc.Text = pc.ToString("x4");
            textBoxBus.Text = bus.ToString("x4");
            textBoxIr.Text = ir.ToString("x4");
            textBoxRr.Text = rr.ToString("x2");
            textBoxRd.Text = rd.ToString("x2");
            textBoxTemp.Text = temp.ToString("x4");
            textBoxLa.Text = la.ToString("x2");
            textBoxLt.Text = lt.ToString("x4");
            textBoxImar.Text = imar.ToString("x4");
            textBoxImdr.Text = imdr.ToString("x2");
        }

        /// <summary>
        /// 更新界面上的通用寄存器和sr
        /// </summary>
        private void UpdateListBoxRegisters()
        {
            for (int i = 0; i < registers.Length; i++)
            {
                listBoxRegisters.Items[i] = string.Format("{0,3}: 0x{1:x2}", registerNames[i], registers[i]);
            }

            for (int i = 0; i < sr.Length; i++)
            {
                listBoxSr.Items[i] = string.Format("{0}: {1}", (srNames)i, sr[i]);
            }
        }

        /// <summary>
        /// 更新界面上的列表的被选中项
        /// </summary>
        private void UpdateListBoxSelectedIndex()
        {
            if (currentMCodeIndex < currentMCodeList.Count)
            {
                listBoxMCode.SelectedIndex = currentMCodeIndex;
            }

            if (currentInstructionIndex < instructions.Count)
            {
                listBoxCode.SelectedIndex = currentInstructionIndex;
                listBoxBCode.SelectedIndex = currentInstructionIndex;
            }

            // 不会超出范围，所以不需要判定
            listBoxCycle.SelectedIndex = currentCycle;
        }

        /// <summary>
        /// 清空界面上的微指令列表
        /// </summary>
        public void ClearListBoxMCode()
        {
            listBoxMCode.Items.Clear();
        }
        #endregion

        #region 汇编解析方法
        /// <summary>
        /// 解析汇编文件
        /// </summary>
        /// <param name="lines">文件内容，数组每一个元素为一行的内容</param>
        private void ParseLines(string[] lines)
        {
            instructions.Clear();
            for (int i = 0; i < lines.Length; i++)
            {
                string code = lines[i].Trim().ToUpper();
                if (string.IsNullOrEmpty(code))
                {
                    continue;
                }

                try
                {
                    Instruction instruction = ParseCode(code);
                    Console.WriteLine(instruction);
                    instructions.Add(instruction);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("第{0}行：{1}\n错误原因：{2}", i + 1, code, ex.Message), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
        }

        /// <summary>
        /// 解析一行汇编代码
        /// </summary>
        /// <param name="code">汇编代码</param>
        /// <returns></returns>
        private Instruction ParseCode(string code)
        {
            Instruction result = new Instruction();
            result.code = code;

            string pattern = @"([A-Z]+)( +([A-Z1-9]+)( *, *([A-Z1-9]+))?)?";
            Match match = Regex.Match(code, pattern);
            string[] groups = new string[3];

            if (match == null)
            {
                throw new Exception("无法解析的格式");
            }

            if (match.Groups[1].Success)
            {
                groups[0] = match.Groups[1].Value;
            }

            if (match.Groups[3].Success)
            {
                groups[1] = match.Groups[3].Value;
            }

            if (match.Groups[5].Success)
            {
                groups[2] = match.Groups[5].Value;
            }

            if (string.IsNullOrEmpty(groups[0]))
            {
                throw new Exception("无法找到OP字段");
            }

            List<string> registerNameList = new List<string>(registerNames);

            switch (groups[0])
            {
                case "ADD":
                    {
                        if (!registerNameList.Contains(groups[1]) ||
                            !registerNameList.Contains(groups[2]))
                        {
                            throw new Exception("不存在的寄存器名！");
                        }
                        int op = 0x0c00;
                        int rd = registerNameList.IndexOf(groups[1]);
                        int rr = registerNameList.IndexOf(groups[2]);
                        int bCode = op + (rd << 4) + rr;

                        result.bCode = bCode;
                        result.op = "ADD";
                        result.a1 = rd;
                        result.a2 = rr;

                        break;
                    }
                case "SUB":
                    {
                        if (!registerNameList.Contains(groups[1]) ||
                            !registerNameList.Contains(groups[2]))
                        {
                            throw new Exception("不存在的寄存器名！");
                        }
                        int op = 0x0800;
                        int rd = registerNameList.IndexOf(groups[1]);
                        int rr = registerNameList.IndexOf(groups[2]);
                        int bCode = op + (rd << 4) + rr;

                        result.bCode = bCode;
                        result.op = "SUB";
                        result.a1 = rd;
                        result.a2 = rr;

                        break;
                    }
                case "MUL":
                    {
                        if (!registerNameList.Contains(groups[1]) ||
                            !registerNameList.Contains(groups[2]))
                        {
                            throw new Exception("不存在的寄存器名！");
                        }
                        int op = 0x9c00;
                        int rd = registerNameList.IndexOf(groups[1]);
                        int rr = registerNameList.IndexOf(groups[2]);
                        int bCode = op + (rd << 4) + rr;

                        result.bCode = bCode;
                        result.op = "MUL";
                        result.a1 = rd;
                        result.a2 = rr;

                        break;
                    }
                case "RJMP":
                    {
                        int op = 0xc000;
                        int k = int.Parse(groups[1], System.Globalization.NumberStyles.HexNumber);
                        k &= 0xfff;
                        int bCode = op + k;

                        result.bCode = bCode;
                        result.op = "RJMP";
                        result.k = k;
                        break;
                    }
                case "BRMI":
                    {
                        int op = 0xf100;
                        int k = int.Parse(groups[1], System.Globalization.NumberStyles.HexNumber);
                        k &= 0xff;
                        int bCode = op + k;

                        result.bCode = bCode;
                        result.op = "BRMI";
                        result.k = k;
                        break;
                    }
                case "MOV":
                    {
                        if (!registerNameList.Contains(groups[1]) ||
                            !registerNameList.Contains(groups[2]))
                        {
                            throw new Exception("不存在的寄存器名！");
                        }
                        int op = 0x2c00;
                        int rd = registerNameList.IndexOf(groups[1]);
                        int rr = registerNameList.IndexOf(groups[2]);
                        int bCode = op + (rd << 4) + rr;

                        result.bCode = bCode;
                        result.op = "MOV";
                        result.a1 = rd;
                        result.a2 = rr;

                        break;
                    }
                case "LDI":
                    {
                        if (!registerNameList.Contains(groups[1]))
                        {
                            throw new Exception("不存在的寄存器名！");
                        }

                        int rd = registerNameList.IndexOf(groups[1]);
                        if (rd < 8 || rd > 15)
                        {
                            throw new Exception("目的寄存器只能是R8-R15");
                        }

                        int op = 0xe000;
                        int k = int.Parse(groups[2], System.Globalization.NumberStyles.HexNumber);
                        k &= 0xfff;
                        int bCode = op + ((k & 0xf0) << 4) + (rd << 4) + (k & 0xf);

                        result.bCode = bCode;
                        result.op = "LDI";
                        result.a1 = rd;
                        result.k = k;

                        break;
                    }
                case "LD":
                    {
                        if (!registerNameList.Contains(groups[1]))
                        {
                            throw new Exception("不存在的寄存器名！");
                        }
                        int op = 0x900c;
                        int rd = registerNameList.IndexOf(groups[1]);
                        int bCode = op + (rd << 4);

                        result.bCode = bCode;
                        result.op = "LD";
                        result.a1 = rd;
                        result.a2 = 14;

                        break;
                    }
                case "ST":
                    {
                        if (!registerNameList.Contains(groups[2]))
                        {
                            throw new Exception("不存在的寄存器名！");
                        }
                        int op = 0x920c;
                        int rr = registerNameList.IndexOf(groups[2]);
                        int bCode = op + (rr << 4);

                        result.bCode = bCode;
                        result.op = "ST";
                        result.a1 = 14;
                        result.a2 = rr;

                        break;
                    }
                default:
                    {
                        result.op = "NOP";
                        result.bCode = 0;
                        break;
                    }
            }
            return result;
        }
        #endregion

        #region ALU计算单元
        /// <summary>
        /// 相加
        /// </summary>
        /// <param name="la"></param>
        /// <param name="bus"></param>
        /// <param name="c0"></param>
        /// <returns></returns>
        private int Add(int la, int bus, int c0 = 0)
        {
            int result = la + bus + c0;

            ZFlag(la, bus, result);
            NFlag(la, bus, result);
            CFlag(la, bus, result);
            VFlag(la, bus, result);
            HFlag(la, bus, result);
            HFlag(la, bus, result);
            SFlag(la, bus, result);

            return result & 0xff;
        }

        /// <summary>
        /// 相减
        /// </summary>
        /// <param name="la"></param>
        /// <param name="bus"></param>
        /// <returns></returns>
        private int Sub(int la, int bus)
        {
            bus = ((bus ^ 0xff) + 1) & 0xff;
            return Add(la, bus);
        }

        /// <summary>
        /// 相乘
        /// </summary>
        /// <param name="la"></param>
        /// <param name="bus"></param>
        /// <returns></returns>
        private int Mul(int la, int bus)
        {
            int result = la * bus;

            ZFlag(la, bus, result);
            CFlag(la, bus, result);

            return result & 0xffff;
        }

        /// <summary>
        /// 标志位Z
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="result"></param>
        private void ZFlag(int a, int b, int result)
        {
            if (result == 0)
            {
                sr[(int)srNames.Z] = 1;
            }
            else
            {
                sr[(int)srNames.Z] = 0;
            }
        }

        /// <summary>
        /// 标志位N
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="result"></param>
        private void NFlag(int a, int b, int result)
        {
            if (result > 127)
            {
                sr[(int)srNames.N] = 1;
            }
            else
            {
                sr[(int)srNames.N] = 0;
            }
        }

        /// <summary>
        /// 标志位C
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="result"></param>
        private void CFlag(int a, int b, int result)
        {
            if (result > 255)
            {
                sr[(int)srNames.C] = 1;
            }
            else
            {
                sr[(int)srNames.C] = 0;
            }
        }

        /// <summary>
        /// 标志位V
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="result"></param>
        private void VFlag(int a, int b, int result)
        {
            int temp = 0;
            temp += a + b;
            temp += -(a > 127 ? 255 : 0) - (b > 127 ? 255 : 0);
            if (temp < 0 || temp > 255)
            {
                sr[(int)srNames.V] = 1;
            }
            else
            {
                sr[(int)srNames.V] = 0;
            }
        }

        /// <summary>
        /// 标志位S
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="result"></param>
        private void SFlag(int a, int b, int result)
        {
            sr[(int)srNames.S] = (byte)(sr[(int)srNames.N] ^ sr[(int)srNames.V]);
        }

        /// <summary>
        /// 标志位H
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="result"></param>
        private void HFlag(int a, int b, int result)
        {
            if ((a & 0xf) + (b & 0xf) > 15)
            {
                sr[(int)srNames.H] = 1;
            }
            else
            {
                sr[(int)srNames.H] = 0;
            }
        }
        #endregion

        #region 微指令执行方法
        /// <summary>
        /// PC->BUS, BUS->IMAR, READ, CLEAR LA, 1->C0, ADD, ALU->LT
        /// </summary>
        public void RunnerA()
        {
            bus = pc;
            imar = bus;
            la = 0;
            lt = Add(la, bus, 1);
        }

        /// <summary>
        /// LT->BUS, BUS->PC, WAIT
        /// </summary>
        public void RunnerB()
        {
            bus = lt;
            pc = bus;
            currentInstruction = instructions[imar];
            imdr = instructions[imar].bCode;
        }

        /// <summary>
        /// IMDR->BUS, BUS->IR
        /// </summary>
        public void RunnerC()
        {
            bus = imdr;
            ir = bus;
        }

        /// <summary>
        /// PC-BUS, BUS->LA
        /// </summary>
        public void RunnerD()
        {
            bus = pc;
            la = bus;
        }

        /// <summary>
        /// TEMP->BUS, BUS->Rd
        /// </summary>
        public void RunnerE()
        {
            bus = temp;
            registers[currentInstruction.a1] = bus & 0xff;
        }

        /// <summary>
        /// Rs->BUS, BUS->RR
        /// </summary>
        public void RunnerF()
        {
            bus = registers[currentInstruction.a2];
            rr = bus;
        }

        /// <summary>
        /// TEMP->BUS, 1->C0, ADD, ALU->LT
        /// </summary>
        public void RunnerG()
        {
            bus = temp;
            lt = Add(la, bus, 1);
        }

        /// <summary>
        /// Rd->BUS, BUS->RD
        /// </summary>
        public void RunnerH()
        {
            bus = registers[currentInstruction.a1];
            rd = bus;
        }

        /// <summary>
        /// RD->BUS, BUS->LA
        /// </summary>
        public void RunnerM()
        {
            bus = rd;
            la = bus;
        }

        /// <summary>
        /// RR->BUS, MUL
        /// </summary>
        public void RunnerI1()
        {
            bus = rr;
        }

        /// <summary>
        /// RR->BUS, ADD, ALU->LT
        /// </summary>
        public void RunnerI2()
        {
            bus = rr;
            lt = Add(la, bus);
        }

        /// <summary>
        /// RR->BUS, SUB, ALU->LT
        /// </summary>
        public void RunnerI3()
        {
            bus = rr;
            lt = Sub(la, bus);
        }

        /// <summary>
        /// ALU->LT, LT->BUS, BUS->Ra
        /// </summary>
        public void RunnerL1()
        {
            lt = Mul(la, bus);
            bus = lt;
            registers[0] = bus & 0xff;
            registers[1] = (bus >> 8) & 0xff;
        }

        /// <summary>
        /// LT->BUS, BUS->Rd
        /// </summary>
        public void RunnerL2()
        {
            bus = lt;
            registers[currentInstruction.a1] = bus & 0xff;
        }

        /// <summary>
        /// RR->BUS, BUS->Rd
        /// </summary>
        public void RunnerJ()
        {
            bus = rr;
            registers[currentInstruction.a1] = bus & 0xff;
        }

        /// <summary>
        /// LT->BUS, BUS->PC
        /// </summary>
        public void RunnerK()
        {
            bus = lt;
            pc = bus;
        }

        /// <summary>
        /// 1->FT
        /// </summary>
        public void RunnerV()
        {
            currentCycle = 0;
        }

        /// <summary>
        /// 1->ST
        /// </summary>
        public void RunnerW()
        {

            currentCycle = 1;
        }

        /// <summary>
        /// 1->DT
        /// </summary>
        public void RunnerX()
        {

            currentCycle = 2;
        }

        /// <summary>
        /// 1->ET
        /// </summary>
        public void RunnerY()
        {
            currentCycle = 3;
        }

        /// <summary>
        /// 空操作
        /// </summary>
        public void RunnerZ()
        {
            // 啥也不干
        }
        #endregion

        #region 总执行方法
        /// <summary>
        /// 单步执行
        /// </summary>
        /// <returns>执行是否成功</returns>
        private bool Step()
        {
            // 判定微程序是否执行完毕
            if (currentMCodeIndex >= currentMCodeList.Count)
            {
                currentInstructionIndex = pc;

                // 判定所有指令是否执行完毕
                if (currentInstructionIndex >= instructions.Count)
                {
                    return false;
                }

                // 使用当前指令来初始化微指令列表
                string currentOp = instructions[currentInstructionIndex].op;
                InitCurrentMProgram(currentOp);
                InitListBoxMCode();
            }

            // 先更新列表选中项
            UpdateListBoxSelectedIndex();

            // 保存变量
            SaveAllVar();

            // 开始执行微指令
            temp = instructions[currentInstructionIndex].k;
            string currentMCodeId = currentMCodeList[currentMCodeIndex];
            mCodeRunnerDelegate runner = mCodeRunner[currentMCodeId];
            runner();

            // 更新界面
            UpdateTextBoxRegisters();
            UpdateListBoxRegisters();

            // 为执行下一条微指令做准备
            currentMCodeIndex++;

            return true;
        }

        /// <summary>
        /// 自动全部执行所有指令
        /// </summary>
        private void Run()
        {
            while (running && Step())
            {
                Thread.Sleep(200);
            }
            running = false;
            buttonRun.Text = "全部执行";
        }

        /// <summary>
        /// 开始工作线程
        /// </summary>
        private void StartWorker()
        {
            buttonRun.Text = "停止执行";
            running = true;
            worker = new Thread(Run);
            worker.Start();
        }

        /// <summary>
        /// 停止工作线程
        /// </summary>
        private void StopWorker()
        {
            running = false;
            if (worker != null && worker.IsAlive)
            {
                worker.Join();
            }
            buttonRun.Text = "全部执行";
        }
        #endregion

        #region 工具方法
        /// <summary>
        /// 保存所有指令到当前目录下的文件里
        /// </summary>
        private void SaveInstructions()
        {
            using (StreamWriter streamWriter = File.AppendText(".\\output.txt"))
            {
                streamWriter.WriteLine("读取汇编文件：");

                for (int i = 0; i < instructions.Count; i++)
                {
                    streamWriter.WriteLine(string.Format("0x{0:x4}: {1, -15}{2}", i, instructions[i].code, ToBitString(instructions[i].bCode)));
                }

                streamWriter.WriteLine("");
            }
        }

        /// <summary>
        /// 保存所有寄存器的值到当前目录下的文件里
        /// </summary>
        private void SaveAllVar()
        {
            using (StreamWriter streamWriter = File.AppendText(".\\output.txt"))
            {
                // 当前指令
                streamWriter.WriteLine(string.Format("当前指令是：{0}", instructions[currentInstructionIndex].code));

                // 当前微指令
                streamWriter.WriteLine(string.Format("当前微指令是：{0}", mCode[currentMCodeList[currentMCodeIndex]]));

                // 当前指令周期
                streamWriter.WriteLine(string.Format("当前指令周期是：{0}", cycleNames[currentCycle]));

                //当前所有的寄存器值
                streamWriter.Write(string.Format("pc: 0x{0:x4}, " +
                                                 "bus: 0x{1:x4}, " +
                                                 "ir: 0x{2:x4}, " +
                                                 "rr: 0x{3:x2}, " +
                                                 "rd: 0x{4:x2}, " +
                                                 "temp: 0x{5:x4}, " +
                                                 "la: 0x{6:x2}, " +
                                                 "lt: 0x{7:x4}, " +
                                                 "imar: 0x{8:x4}, " +
                                                 "imdr: 0x{9:x2}",
                                                 pc, bus, ir, rr, rd, temp, la, lt, imar, imdr));

                streamWriter.Write(string.Format("\nsr: "));
                for (int i = 0; i < sr.Length; i++)
                {
                    streamWriter.Write(string.Format("{0}: {1}, ", (srNames)i, sr[i]));
                }

                streamWriter.Write(string.Format("\nregisters: "));
                for (int i = 0; i < registers.Length; i++)
                {
                    streamWriter.Write(string.Format("{0,3}: 0x{1:x2}, ", registerNames[i], registers[i]));
                }

                streamWriter.WriteLine("\n");
            }
        }

        /// <summary>
        /// 将数字格式化为易于查看的二进制形式字符串，
        /// 如十进制的17会被格式化为0000 0000 0010 0000
        /// </summary>
        /// <param name="number">被格式化的数字</param>
        /// <returns>二进制数字字符串</returns>
        private string ToBitString(int number)
        {
            string result = "";
            int n = 0;
            int count = 16;
            while (count-- > 0)
            {
                result = (number & 0x1) + result;
                number >>= 1;

                n++;
                if (n % 4 == 0)
                {
                    result = " " + result;
                    n = 0;
                }
            }

            return result;
        }
        #endregion

        #region 按钮点击事件
        /// <summary>
        /// 导入按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonImport_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                string[] lines = File.ReadAllLines(fileName);
                ParseLines(lines);
                InitListBoxInstruction();
                SaveInstructions();
            }
        }

        /// <summary>
        /// 单步执行按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStep_Click(object sender, EventArgs e)
        {
            if (running)
            {
                return;
            }

            Step();
        }

        /// <summary>
        /// 全部执行按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRun_Click(object sender, EventArgs e)
        {
            if (running)
            {
                StopWorker();
            }
            else
            {
                StartWorker();
            }
        }

        /// <summary>
        /// 重置按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReset_Click(object sender, EventArgs e)
        {
            StopWorker();
            ClearListBoxMCode();
            InitAllVar();
            UpdateListBoxRegisters();
            UpdateTextBoxRegisters();
            UpdateListBoxSelectedIndex();
        }
        #endregion
    }
}
