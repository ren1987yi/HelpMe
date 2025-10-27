namespace HelpMe.Core
{
    internal class PersonProperty1
    {
        public int Life { get; set; }
        public float Speed { get; set; }
        public int WeaponCount { get; set; }

        //近战攻击力
        public float FightPower { get; set; }
        //远程攻击
        public float RemotePower { get; set; }
        
        //防御
        public float Defence { get; set; }
        //闪避
        public float Dodge { get; set; }
        //幸运
        public float Lucky { get; set; }
        //伤害
        public float Damage { get; set; }

        //攻击距离
        public float Range { get; set; }
        //攻击速度
        public float AttackSpeed { get; set; }
    }
}
