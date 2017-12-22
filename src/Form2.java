import java.awt.Color;
import java.awt.EventQueue;
import java.util.logging.Logger;
import javax.swing.JFrame;
import javax.swing.JButton;
import javax.swing.JColorChooser;
import javax.swing.JComponent;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.TransferHandler;


import java.awt.event.ActionListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.event.ActionEvent;

public class Form2 {

	JFrame frame;
	
	
	
	private Dragg_label_color label_color;
	public static Drop_panel panel;
	private CallbackKut scb ;
	private Logger logger;
	/**
	 * Launch the application.
	 */

	

	/**
	 * Create the application.
	 */
	public Form2(CallbackKut scb) {
		initialize();
		this.scb=scb;
		logger = Logger.getGlobal();
			
	}

	/**
	 * Initialize the contents of the frame.
	 */
	private void initialize() {
		frame = new JFrame();
		frame.setBounds(100, 100, 707, 560);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.getContentPane().setLayout(null);
		
		panel = new Drop_panel();
		panel.setBounds(29, 33, 474, 293);
		frame.getContentPane().add(panel);
				panel.setLayout(null);

		JButton btnCreate = new JButton("Create");
		btnCreate.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				if(scb != null) {
					if(panel.GetKut()!=null) {
						scb.takekut(panel.GetKut());
						logger.info("Лодка создана");
					}
				}
				frame.dispose();
			}
		});
		btnCreate.setBounds(524, 423, 97, 25);
		frame.getContentPane().add(btnCreate);

		Dragg_label_cutters label_kit = new Dragg_label_cutters("Лодка");
		label_kit.setBounds(29, 400, 56, 16);
		frame.getContentPane().add(label_kit);

		Dragg_label_cutters label_gorbach = new Dragg_label_cutters("Катер");
		label_gorbach.setBounds(29, 427, 126, 16);
		frame.getContentPane().add(label_gorbach);

		
		JButton button_cancel = new JButton("\u041E\u0442\u043C\u0435\u043D\u0430");
		 		button_cancel.addActionListener(new ActionListener() {
		 			public void actionPerformed(ActionEvent e) {
		 				logger.info("Выход из формы для создания лодки");
		 				frame.dispose();
		 			}
		 		});
		 		button_cancel.setBounds(524, 460, 89, 23);
		 		frame.getContentPane().add(button_cancel);
		 		frame.setVisible(true);
				

		JButton button_color = new JButton("Выбор цвета");
		button_color.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				
				Color color = JColorChooser.showDialog(frame, "Select a color",Color.BLACK);
				label_color.setColor(color);
				label_color.repaint();
			}
		});
		button_color.setBounds(322, 423, 133, 25);
		frame.getContentPane().add(button_color);

		label_color = new Dragg_label_color("цвет");
		label_color.setBounds(200, 427, 56, 16);
		frame.getContentPane().add(label_color);
		
		
		
		
		
		
	}
	
	
}



