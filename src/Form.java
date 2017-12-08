import java.awt.*;
import javax.swing.*;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;
import javax.swing.border.BevelBorder;
import javax.swing.border.LineBorder;
import javax.swing.border.SoftBevelBorder;
import javax.swing.event.ListSelectionEvent;
import javax.swing.event.ListSelectionListener;


public class Form {

	private Parking parking;

	private JFrame frame;
	private JLabel lblNewLabel_1;
	private ReturnP returnPanel;
	private JPanel panel;
	private JTextField formattedTextField;
	private JPanel panelGet;
	private JButton buttonGet;
	private JPanel panel_1;
	private JList listBoxLevels;
	private Form2 form2;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					Form window = new Form();
					window.frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the application.
	 */
	public Form() {
		parking= new Parking(20);
		initialize();	
		listBoxLevels.setSelectedIndex(parking.getCurrentLevel());
	}


	private void buttonGet_Click() {
		if (listBoxLevels.getSelectedIndex() < 0) {
			return;
		}
		try {
			ITransport kut = parking.GetkutInparking(Integer.parseInt(formattedTextField.getText()));
			if (kut != null) {
				kut.SetPosition(5, 5);
				returnPanel = new ReturnP(kut);
				returnPanel.setBackground(Color.WHITE);
				returnPanel.setBounds(10, 94, 139, 201);
				panelGet.add(returnPanel);
				
				panel.repaint();
			}
		}catch(Exception e){
			JOptionPane.showMessageDialog(frame, "Что-то пошло не так!");
		}

	}

	/**
	 * Initialize the contents of the frame.
	 */
	@SuppressWarnings({ "rawtypes", "unchecked" })
	private void initialize() {
		frame = new JFrame();
		frame.getContentPane().setBackground(UIManager.getColor("Button.background"));
		frame.getContentPane().setForeground(Color.BLACK);
		frame.setBounds(100, 100, 739, 508);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

		JButton btnCreate = new JButton("Create");
		btnCreate.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				form2 = new Form2((new CallbackKut(){

					@Override
					public void takekut(ITransport kut) {
						int place = parking.PutkutiInparking(kut);
						panel.repaint();
						JOptionPane.showMessageDialog(frame, "Ваше место " + place);
						
					}
				}));
				form2.frame.setVisible(true);	
				
			}
		});
		btnCreate.setBounds(433, 406, 97, 25);
		frame.getContentPane().add(btnCreate);


		panelGet = new JPanel();
		panelGet.setBounds(554, 153, 159, 306);
		panelGet.setBorder(new LineBorder(new Color(0, 0, 0)));
		panelGet.setToolTipText("");
		panelGet.setLayout(null);

		lblNewLabel_1 = new JLabel("Забрать лодку");
		lblNewLabel_1.setBounds(10, 5, 139, 14);
		panelGet.add(lblNewLabel_1);


		formattedTextField = new JTextField();
		formattedTextField.setBounds(10, 29, 59, 20);
		panelGet.add(formattedTextField);

		buttonGet = new JButton("забрать");
		buttonGet.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				buttonGet_Click();
			}
		});
		buttonGet.setBounds(10, 60, 111, 23);
		panelGet.add(buttonGet);
		
		panel_1 = new JPanel();
		panel_1.setBorder(new LineBorder(new Color(0, 0, 0)));
		panel_1.setBounds(554, 11, 159, 140);
		panel_1.setLayout(null);

		JLabel lblNewLabel_2 = new JLabel("\u0423\u0440\u043E\u0432\u043D\u0438:");
		lblNewLabel_2.setBounds(59, 5, 62, 14);
		panel_1.add(lblNewLabel_2);

		String[] elements = new String[5];
		for (int i = 0; i < 5; i++) {
			elements[i] = "Level" + (i+1);
		}
		listBoxLevels = new JList(elements);
		listBoxLevels.setBounds(10, 18, 139, 111);
		listBoxLevels.setLayoutOrientation(JList.VERTICAL);
		listBoxLevels.setVisibleRowCount(0);
		listBoxLevels.addListSelectionListener(new ListSelectionListener() {

			@Override
			public void valueChanged(ListSelectionEvent e) {
				parking.setCurrentLevel(listBoxLevels.getSelectedIndex());
				panel.repaint();
			}

		});
		panel_1.add(listBoxLevels);
		
		panel = new Ris(parking,listBoxLevels);
		panel.setBounds(10, 11, 534, 382);
		panel.setBorder(new SoftBevelBorder(BevelBorder.RAISED, null, null, null, null));
		panel.setBackground(Color.WHITE);
		
		JMenuBar menuBar = new JMenuBar();
		JMenu file = new JMenu("Меню");
		JMenuItem save = new JMenuItem("Сохранить");
		JMenuItem load = new JMenuItem("загрузить");
		save.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent arg0) {
				JFileChooser fc = new JFileChooser();  
				if (fc.showSaveDialog(frame) == JFileChooser.APPROVE_OPTION) {  
				    try {  
				        ((Ris) panel).saveParking(fc.getSelectedFile().getPath()); 
				        JOptionPane.showMessageDialog(frame, "сохранение успешно");
				    }  
				    catch (Exception e) {
				    	System.out.println("что-то пошло не так");
				    }  
				} 
			}
		});
		load.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				JFileChooser fc = new JFileChooser();  
				if (fc.showOpenDialog(frame) == JFileChooser.APPROVE_OPTION) {  
					((Ris) panel).loadParking(fc.getSelectedFile().getPath());
					JOptionPane.showMessageDialog(frame, "Загрузка успешна");
				}
			}
		});
		file.add(save);
		file.add(load);
		menuBar.add(file);
		frame.setJMenuBar(menuBar);
		
		frame.getContentPane().setLayout(null);
		frame.getContentPane().add(panel);
		frame.getContentPane().add(panelGet);
		frame.getContentPane().add(panel_1);
	}
}
