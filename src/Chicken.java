
public class Chicken {
	private int has_ready = 0;

	public int getHas_ready() {
		return has_ready;
	}

	public boolean cutting;

	public void setcutting(boolean cutting) {
		this.cutting = cutting;

	}

	public boolean getcutting() {
		return cutting;
	}

	public void GetHeat() {
		if (has_ready < 10) {
			has_ready++;
		}
	}
}
