using Model.Common;
using Model.Enum;
using System;

namespace Model.DB
{
    public class BlockInfo
    {
        public int block_type { get; set; }

        public string specode { get; set; }

        public int @decimal { get; set; }

        [UnValue]
        public BlockEnum block_type_enum
        {
            get { return (BlockEnum)block_type; }
            set { block_type = (int)value; }
        }
    }
}