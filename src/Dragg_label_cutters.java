import java.awt.Color;
import java.awt.Label;
import java.awt.datatransfer.StringSelection;
import java.awt.datatransfer.Transferable;
import java.awt.dnd.DnDConstants;
import java.awt.dnd.DragGestureEvent;
import java.awt.dnd.DragGestureListener;
import java.awt.dnd.DragSource;
import java.awt.dnd.DragSourceDragEvent;
import java.awt.dnd.DragSourceDropEvent;
import java.awt.dnd.DragSourceEvent;
import java.awt.dnd.DragSourceListener;

@SuppressWarnings("serial")
public class Dragg_label_cutters extends Label implements DragGestureListener, DragSourceListener {
	DragSource dragSource;
	
	public Dragg_label_cutters(String text) {
		
		setText(text );
		
		dragSource = new DragSource();

		dragSource.createDefaultDragGestureRecognizer(this, DnDConstants.ACTION_COPY_OR_MOVE, this);
	}
	public void setColor(Color color){
		setForeground(color);
	}

	@Override
	public void dragDropEnd(DragSourceDropEvent dsde) {
		// TODO Auto-generated method stub

	}

	@Override
	public void dragEnter(DragSourceDragEvent dsde) {
		// TODO Auto-generated method stub

	}

	@Override
	public void dragExit(DragSourceEvent dse) {
		// TODO Auto-generated method stub

	}

	@Override
	public void dragOver(DragSourceDragEvent dsde) {
		// TODO Auto-generated method stub

	}

	@Override
	public void dropActionChanged(DragSourceDragEvent dsde) {
		// TODO Auto-generated method stub

	}

	@Override
	public void dragGestureRecognized(DragGestureEvent arg0) {
		Transferable transferable = new StringSelection(getText());

		dragSource.startDrag(arg0, DragSource.DefaultCopyDrop, transferable, this);

	}

}
