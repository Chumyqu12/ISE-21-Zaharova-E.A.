
public class WaterTap {
	 public boolean State=false;
	 
	 
	 public void setState(boolean State) {
			this.State = State;

		}

		public boolean getState() {
			return State;
		}
	 

     public Water GetWater() {
         if (State)
         {
             return new Water();

         }
         else {
             return null;
         }
     }
     public void WashPotato(Potato p)
		{
			if (State)
			{
				p.Dirty = false;

			}
		}

		public void WashCarrot(Carrot c)
		{
			if (State)
			{
				c.Dirty = false;

			}
		}


		public void WashOnion(Onion o)
		{
			if (State)
			{
				o.Dirty = false;

			}
		}
}
