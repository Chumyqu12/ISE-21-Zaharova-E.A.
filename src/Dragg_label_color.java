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
public class Dragg_label_color extends Label implements DragGestureListener, DragSourceListener {
	DragSource dragSource;

	public Dragg_label_color(String text) {

		setText(text);

		dragSource = new DragSource();

		dragSource.createDefaultDragGestureRecognizer(this, DnDConstants.ACTION_COPY_OR_MOVE, this);
	}

	public void setColor(Color color) {
		setForeground(color);
	}

	@Override
	public void dragDropEnd(DragSourceDropEvent dsde) {
		// TODO Auto-generated method stub

	}

	@Override
	public void dragEnter(DragSourceDragEvent dsde) {

	}

	@Override
	public void dragExit(DragSourceEvent dse) {

	}

	@Override
	public void dragOver(DragSourceDragEvent dsde) {

	}

	@Override
	public void dropActionChanged(DragSourceDragEvent dsde) {

	}

	@Override
	public void dragGestureRecognized(DragGestureEvent arg0) {
		Transferable transferable = new StringSelection("" + getForeground().getRGB());

		dragSource.startDrag(arg0, DragSource.DefaultCopyDrop, transferable, this);

	}

}
