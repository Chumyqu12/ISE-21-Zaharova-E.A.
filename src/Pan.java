
public class Pan {
	private Water water;
	private Potato[] potato;
	private Salt salt;
	private Onion[] onion;
	private Lapsha lapsha;
	private Chicken chicken;
	private Carrot[] carrot;

	public boolean ReadyToGo() {
		return Check();
	}

	
	public void AddWater(Water w) {

		if (water == null) {
			water = w;
			return;
		}

	}

	public void AddSalt(Salt s) {
		salt = s;
	}

	public void AddPotato(Potato[] p) {

		if (potato == null) {
			potato = p;
			return;
		}

	}

	public void AddCarrot(Carrot[] c) {

		if (carrot == null) {
			carrot = c;
			return;
		}

	}

	public void AddChicken(Chicken c) {
		chicken = c;
	}

	public void AddOnion(Onion[] o) {

		if (onion == null) {
			onion = o;
			return;
		}

	}

	public void AddLapsha(Lapsha t) {
		lapsha = t;
	}

	private boolean Check() {
		if (water == null) {
			return false;
		}
		if (potato.length == 0) {
			return false;
		}
		if (carrot.length == 0) {
			return false;
		}
		if (chicken == null) {
			return false;
		}
		if (onion.length == 0) {
			return false;
		}
		if (lapsha == null) {
			return false;
		}
		for (int i = 0; i < carrot.length; ++i) {
			if (carrot[i] == null) {
				return false;
			}
		}
		for (int i = 0; i < potato.length; ++i) {
			if (potato[i] == null) {
				return false;
			}
		}
		for (int i = 0; i < onion.length; ++i) {
			if (onion[i] == null) {
				return false;
			}
		}
		return true;
	}

	public void Getheat() {
		if (!Check()) {
			return;
		}
		if (water != null) {
			if (water.gettemp() < 100) {

				water.Getheat();

				boolean flag = false;

				switch (water.gettemp()) {
				case 20:
					flag = true;
					break;
				case 40:
					flag = true;
					break;
				case 60:
					flag = true;
					break;
				case 80:
					flag = true;
					break;
				case 100:
					flag = true;
					break;
				}
				if (flag) {
					for (int i = 0; i < potato.length; ++i) {
						potato[i].GetHeat();
					}
					for (int i = 0; i < onion.length; ++i) {
						onion[i].GetHeat();
					}
					for (int i = 0; i < carrot.length; ++i) {
						carrot[i].GetHeat();
					}
					lapsha.GetHeat();
					chicken.GetHeat();
				}
			} else {
				for (int i = 0; i < potato.length; ++i) {
					potato[i].GetHeat();
				}
				for (int i = 0; i < onion.length; ++i) {
					onion[i].GetHeat();
				}
				for (int i = 0; i < carrot.length; ++i) {
					carrot[i].GetHeat();
				}
				lapsha.GetHeat();
				chicken.GetHeat();

			}
		}
	}

	public boolean Isready() {

		if (water.gettemp() < 100) {
			return false;
		}

		for (int i = 0; i < potato.length; ++i) {
			if (potato[i].getHas_ready() < 10) {
				return false;
			}
		}
		for (int i = 0; i < onion.length; ++i) {
			if (onion[i].getHas_ready() < 10) {
				return false;
			}
		}
		for (int i = 0; i < carrot.length; ++i) {
			if (carrot[i].getHas_ready() < 10) {
				return false;
			}
		}
		if (chicken.getHas_ready() < 10) {
			return false;
		}
		if (lapsha.getHas_ready() < 10) {
			return false;
		}
		return true;

	}
}
