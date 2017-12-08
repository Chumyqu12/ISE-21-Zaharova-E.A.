
import java.util.HashMap;
import java.util.Map;

public class ClassArray<T extends ITransport> {

	private Map<Integer, T> places;

	private int maxCount;

	private T defaultValue;

	public ClassArray(int size, T defVal) {
		defaultValue = defVal;
		places = new HashMap<>();
		maxCount = size;
	}

	public T GetKut(int index) {
		if (places.containsKey(index)) {
			return places.get(index);
		}
		return defaultValue;
	}

	public int Add(T kut) {
		if (places.size() == maxCount) {
			return -1;
		}

		for (int i = 0; i < places.size(); i++) {
			if (CheakFreePlace(i)) {
				places.put(i, kut);
				return i;
			}
		}
		places.put(places.size(), kut);
		return places.size() - 1;
	}

	public T Get(int index) {
		if (places.containsKey(index)) {
			return places.remove(index);
		}
		return defaultValue;
	}

	private boolean CheakFreePlace(int index) {
		return !places.containsKey(index);

	}



}
