import java.awt.Color;


import java.awt.Graphics;
import java.awt.datatransfer.DataFlavor;
import java.awt.datatransfer.Transferable;
import java.awt.datatransfer.UnsupportedFlavorException;
import java.awt.dnd.DnDConstants;
import java.awt.dnd.DropTarget;
import java.awt.dnd.DropTargetDragEvent;
import java.awt.dnd.DropTargetDropEvent;
import java.awt.dnd.DropTargetEvent;
import java.awt.dnd.DropTargetListener;
import java.io.IOException;
import java.util.logging.Logger;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.TransferHandler;





public class Drop_panel extends JPanel implements DropTargetListener {
	private  JLabel label_color_cutter;
	private JLabel label_color_lodka;
	private Logger logger;
	ITransport kut;
	Color color;
	Color dopColor;
	public Drop_panel(){
		new DropTarget(this,this);
		logger = Logger.getGlobal();
		
		label_color_lodka = new Drop_label_color("цвет лодки",new Callback() {
			@Override
			public void setbred(boolean bred) {
				if(kut!=null && bred) {
					color=label_color_lodka.getForeground();
					kut.SetColor(color);
					logger.info("Выбран " + color.toString() +"Цвет лодки");
					repaint();
				}
				bred=false;
				
			}		
		});
		label_color_lodka.setBounds(12, 13, 57, 16);
		
		
		label_color_cutter = new Drop_label_color(
						"цвет катера",new Callback() {
							@Override
							public void setbred(boolean bred) {
								if(kut!=null && bred) {
									color=label_color_lodka.getForeground();
									dopColor=label_color_cutter.getForeground();
									kut.SetColor(color);
									kut.SetdopColor(dopColor);
									logger.info("Выбран " + dopColor.toString() + "цвет катера");
									repaint();
								}
								bred=false;
								
							}		
						});
		label_color_cutter.setBounds(12, 42, 143, 16);
				
				label_color_cutter.setTransferHandler(new TransferHandler("Color"));
				
				this.add(label_color_lodka);
				this.add(label_color_cutter);
				
				
				
				
	}
	
	public void paint(Graphics g) {
		super.paint(g);
		draw(g);
	}
	private void draw(Graphics g){
		if(kut!=null){
			kut.drawLodka(g);
			kut.SetPosition(150, 150);
		}
	}
	public ITransport GetKut(){
		if (kut!=null){
		return kut;
		}else{
			return null;
		}
	}


	@Override
	public void dragEnter(DropTargetDragEvent dtde) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void dragExit(DropTargetEvent dte) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void dragOver(DropTargetDragEvent dtde) {
		// TODO Auto-generated method stub
		
	}


	@Override
	public void drop(DropTargetDropEvent dtde) {
		try {

			Transferable transferable = dtde.getTransferable();

			if (transferable.isDataFlavorSupported(DataFlavor.stringFlavor)) {

				dtde.acceptDrop(DnDConstants.ACTION_COPY_OR_MOVE);

				String dragContents = (String) transferable.getTransferData(DataFlavor.stringFlavor);
				
				if(dragContents.equals("Лодка")){
					color=label_color_lodka.getForeground();
					kut =new Lodka(150, 7, 300, 300, color);
					kut.SetPosition(150, 150);
					logger.info("Выбрана лодка");
					repaint();
					
					
				}else{
					color=label_color_lodka.getForeground();
					dopColor=label_color_cutter.getForeground();
					kut= new Cutter(150,7,300,250,color,true,dopColor);
					kut.SetPosition(150, 150);
					logger.info("Выбран катер");
					repaint();
				} 
				

			} else {

				dtde.rejectDrop();

			}

		} catch (IOException e) {

			dtde.rejectDrop();

		} catch (UnsupportedFlavorException e) {

			dtde.rejectDrop();

		}
		
	}

	@Override
	public void dropActionChanged(DropTargetDragEvent dtde) {
		// TODO Auto-generated method stub
		
	}

}
