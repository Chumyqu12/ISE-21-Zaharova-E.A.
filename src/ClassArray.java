
import java.lang.reflect.Array;


public class ClassArray<T extends ITransport> {
	
	private T[] places;
	
	private T defaultValue;
	
	@SuppressWarnings("unchecked")
	public ClassArray(int size, T defVal, Class<T> TClass ){
		defaultValue=defVal;
		places=(T[])Array.newInstance(TClass,size);
		for(int i=0;i<places.length;i++){
			places[i]=defaultValue;
		}
	}
	
	public T Getkut(int index){
		if(index>-1 && index<places.length){
			return places[index];
		}
		return defaultValue;
	}
	
	public int Add(T kut){
		for(int i=0;i<places.length;i++){
			if(CheakFreePlace(i)){
				places[i]=kut;
				return i;
			}
		}
		return -1;
	}
	
	public T Get(int index){
		if(!CheakFreePlace(index)){
			T kut =places[index];
			places[index]=defaultValue;
			return kut;
		}
		return defaultValue;
	}
	
	private boolean CheakFreePlace(int index)
    {
        if (index < 0 || index > places.length)
        {
            return false;
        }
        if (places[index] == null)
        {
            return true;
        }
        if (places[index].equals(defaultValue))
        {
            return true;
        }
        return false;

    }
}