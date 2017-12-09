
import java.awt.Color;
import java.awt.Graphics;
import java.awt.datatransfer.DataFlavor;
import java.awt.datatransfer.Transferable;
import java.awt.datatransfer.UnsupportedFlavorException;
import java.awt.dnd.*;
import java.io.IOException;

import javax.swing.*;

@SuppressWarnings("serial")
public class Drop_label_color extends JLabel implements DropTargetListener {
	private Callback ccb;

	
	public Drop_label_color(String text, Callback ccb) {
		this.ccb = ccb;
		setText(text);
		new DropTarget(this, this);
	}



	@Override
	public void dragEnter(DropTargetDragEvent dtde) {
		dtde.acceptDrag(DnDConstants.ACTION_COPY);

	}

	@Override
	public void dragOver(DropTargetDragEvent dtde) {
	}

	@Override
	public void dropActionChanged(DropTargetDragEvent dtde) {
	}

	@Override
	public void dragExit(DropTargetEvent dte) {
	}

	@Override
	public void drop(DropTargetDropEvent evt) {

			

		try {
			
			Transferable transferable = evt.getTransferable();

			if (transferable.isDataFlavorSupported(DataFlavor.stringFlavor)) {

				evt.acceptDrop(DnDConstants.ACTION_COPY_OR_MOVE);

				String dragContents = (String) transferable.getTransferData(DataFlavor.stringFlavor);
			

				evt.getDropTargetContext().dropComplete(true);
				
				int argb = Integer.parseInt(dragContents); 
				int alpha = (argb >> 24) & 0xff;
				int red = (argb >> 16) & 0xff;
				int green = (argb >>  8) & 0xff;
				int blue = (argb ) & 0xff;
				
				setForeground(new Color(red,green,blue,alpha));
				if(ccb!=null) {
	    			ccb.setbred(true);
	    		}
				
			

			} else {

				evt.rejectDrop();

			}

		} catch (IOException e) {

			evt.rejectDrop();

		} catch (UnsupportedFlavorException e) {

			evt.rejectDrop();

		}
		
		
	}



}