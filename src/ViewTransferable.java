import java.awt.datatransfer.DataFlavor;
import java.awt.datatransfer.Transferable;
import java.awt.datatransfer.UnsupportedFlavorException;
import java.io.IOException;

class ViewTransferable implements Transferable {
	DataFlavor[] flavors = new DataFlavor[] { DataFlavor.stringFlavor };

	public ViewTransferable() {
	}

	@Override
	public Object getTransferData(DataFlavor flavor) throws UnsupportedFlavorException, IOException {
		if (!isDataFlavorSupported(flavor)) {
			System.out.println("unsuported flavor");
			return null;
		}
		if (flavor.equals(flavors[0])) {
			return (null);
		}
		return null;
	}

	@Override
	public DataFlavor[] getTransferDataFlavors() {
		return flavors;
	}

	@Override
	public boolean isDataFlavorSupported(DataFlavor flavor) {
		if (flavor.equals(flavors[0])) {
			return true;
		}
		return false;
	}
}