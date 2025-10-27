using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMe.Core
{
    internal class PersonBase
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        //等级
        public int Level { get; set; }
        //下一等级的经验需求
        public int NextLevelEXP { get; set; }
        //当前经验值
        public int CurrentEXP {  get; set; }


        public PersonProperty1 PropertyMain { get; set; }

    }
}
