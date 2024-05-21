using System;
using System.Drawing;

namespace addressbook_web_tests
{
	public class Figure
	{
        private bool colored = false;

        public Figure()
		{
		}

        public bool Colored
        {
            get
            {
                return colored;
            }

            set
            {
                colored = value;
            }
        }
    }
}

