
public class Knife {
	public void Clean_potato(Potato p) {
		if (p.getHave_scin()) {
			p.setHave_scin(false);
		}
	}

	public void Clean_carrots(Carrot p) {
		if (p.getHave_scin()) {
			p.setHave_scin(false);
		}
	}

	public void Clean_onion(Onion p) {
		if (p.getHave_scin()) {
			p.setHave_scin(false);
		}
	}

	

	public void Cutting_c(Chicken t) {
		if (t.getcutting()) {
			t.setcutting(false);
		}

	}
}
