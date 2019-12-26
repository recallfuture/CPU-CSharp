namespace Computer
{
    /// <summary>
    /// 指令类
    /// </summary>
    public class Instruction
    {
        /// <summary>
        /// 汇编代码
        /// </summary>
        public string code
        {
            get;
            set;
        }

        /// <summary>
        /// 汇编解析后的二进制代码
        /// </summary>
        public int bCode
        {
            get;
            set;
        }

        /// <summary>
        /// 汇编中的op字段
        /// </summary>
        public string op
        {
            get;
            set;
        }

        /// <summary>
        /// 一地址数
        /// </summary>
        public int a1
        {
            get;
            set;
        }

        /// <summary>
        /// 二地址数
        /// </summary>
        public int a2
        {
            get;
            set;
        }

        /// <summary>
        /// 常量
        /// </summary>
        public int k
        {
            get;
            set;
        }

        public override string ToString()
        {
            return string.Format("code:{0}\nbcode:{1:xxxx}\nop:{2}\na1:{3}\na2:{4}", code, bCode, op, a1, a2);
        }
    }
}
