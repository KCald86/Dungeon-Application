namespace DungeonLibrary
{
    public class Character
    {
        //Field
        private int _maxLife;
        private string _name;
        private int _life;
        private int _hitChance;
        private int _block;
        

        //Props

        public string Name { 
            get { return _name; } 
            set { _name = value; }
        }//end Name

        public int MaxLife
        {
            get { return _maxLife; }
            set { _maxLife = value; }
        }//end MaxLife

        public int Life
        {
            get { return _life; }
            set
            {
                //if (value <= MaxLife)
                //{
                //    _life = value;
                //}//end if
                //else if (value > MaxLife)
                //{
                //    _life = _maxLife;
                //}//end else if
                _life = value<=MaxLife ? value : MaxLife;//Ternarie'd
            }//end set
        }//end Life

        public int Block
        {
            get { return _block; }
            set { _block = value; }
        }//end block

        public int HitChance
        {
            get { return _hitChance; }
            set { _hitChance = value; }
        }//end HitChance


        //CTOR
        public Character(string name, int maxLife, int life, int block, int hitChance)
        {
            Name = name;
            MaxLife = maxLife;
            Life = life;
            Block = block;
            HitChance = hitChance;
        }//end FQ CTOR

        public Character() { }//default CTOR, don't think I need it

        public override string ToString()
        {
            return string.Format("" +
                "{0}\n" +
                "MaxLife: {1}\n" +
                "Life: {2}\n" +
                "Block: {3}" +
                "HitChance: {4}",
                Name,
                MaxLife,
                Block,
                HitChance);
        }//end ToString() not sure if I need this method






    }//end class Character

}//end namespace DungeonLibrary