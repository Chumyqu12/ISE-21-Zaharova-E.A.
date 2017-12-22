import java.io.Serializable;
import java.util.HashMap;
import java.util.Map;

public class ClassArray<T extends ITransport> implements Serializable {
	
	private static final long serialVersionUID = 1L;

	private Map<Integer, T> places;

	private int maxCount;

	private T defaultValue;

	public ClassArray(int size, T defVal) {
		defaultValue = defVal;
		places = new HashMap<>();
		maxCount = size;
	}

	public T GetKut(int index) throws ParkingIndexOutOfRangeException {
		if (places.containsKey(index)) {
			return places.get(index);
		}
		throw new ParkingIndexOutOfRangeException();
	}

	public int Add(T kut) throws ParkingOverflowException {
		for (int i = 0; i < 15; i++) {
			if (CheakFreePlace(i)) {
				places.put(i, kut);
				return i;
			}
		}
		
		throw new ParkingOverflowException();
	}

	public T Get(int index) throws ParkingIndexOutOfRangeException {
		if (places.containsKey(index)) {
			return places.remove(index);
		}
		throw new ParkingIndexOutOfRangeException();
	}

	private boolean CheakFreePlace(int index) {
		return !places.containsKey(index);

	}



}