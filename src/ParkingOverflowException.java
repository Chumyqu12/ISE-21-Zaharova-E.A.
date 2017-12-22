
public class ParkingOverflowException extends Exception {
	public ParkingOverflowException() {
		super("на парковке нет свободных мест");
	}
}
