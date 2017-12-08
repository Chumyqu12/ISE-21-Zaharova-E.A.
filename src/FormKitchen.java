import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.JButton;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;
import javax.swing.JComboBox;
import javax.swing.JTextField;
import javax.swing.JSpinner;
import javax.swing.JCheckBox;

public class FormKitchen {

	private JFrame frame;
	private JTextField textField;
	private JTextField textField_1;
	private JTextField textField_2;
	private JTextField textField_3;
	private JTextField textField_4;
	private JTextField textField_5;
	private Salt salt;

	private WaterTap waterTap;

	private Knife knife;

	private Pan pan;

	private Stove stove;
	private Water water;
	private Potato[] potato;
	private Onion[] onion;
	private Lapsha lapsha;
	private Chicken chicken;
	private Carrot[] carrot;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					FormKitchen window = new FormKitchen();
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
	public FormKitchen() {
		initialize();
		waterTap = new WaterTap();
		knife = new Knife();
		pan = new Pan();
		stove = new Stove();
	}

	/**
	 * Initialize the contents of the frame.
	 */
	private void initialize() {
		frame = new JFrame();
		frame.setBounds(100, 100, 861, 626);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.getContentPane().setLayout(null);

		JButton addProdButton = new JButton(
				"\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C \u043F\u0440\u043E\u0434\u0443\u043A\u0442\u044B");
		addProdButton.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				potato = new Potato[3];
				for (int i = 0; i < potato.length; i++) {
					potato[i] = new Potato();

				}
				carrot = new Carrot[2];
				for (int i = 0; i < carrot.length; i++) {
					carrot[i] = new Carrot();
				}
				onion = new Onion[2];
				for (int i = 0; i < onion.length; i++) {
					onion[i] = new Onion();
				}
				chicken = new Chicken();
				lapsha = new Lapsha();
			}
		});
		addProdButton.setBounds(54, 66, 189, 42);
		frame.getContentPane().add(addProdButton);

		textField = new JTextField();
		textField.setEditable(false);
		textField.setText(
				"\u041B\u0443\u043A,\u041B\u0430\u043F\u0448\u0430,\u041A\u0443\u0440\u0438\u0446\u0430,\u041C\u043E\u0440\u043A\u043E\u0432\u044C,\u041A\u0430\u0440\u0442\u043E\u0448\u043A\u0430");
		textField.setBounds(28, 13, 239, 52);
		frame.getContentPane().add(textField);
		textField.setColumns(10);

		textField_1 = new JTextField();
		textField_1.setEditable(false);
		textField_1.setText("\u0421\u043E\u043B\u044C");
		textField_1.setBounds(28, 123, 116, 22);
		frame.getContentPane().add(textField_1);
		textField_1.setColumns(10);

		JSpinner spinner = new JSpinner();
		spinner.setBounds(156, 121, 30, 22);
		frame.getContentPane().add(spinner);

		textField_2 = new JTextField();
		textField_2.setEditable(false);
		textField_2.setText("\u041A\u0440\u0430\u043D");
		textField_2.setBounds(325, 28, 116, 22);
		frame.getContentPane().add(textField_2);
		textField_2.setColumns(10);

		JCheckBox checkBox = new JCheckBox("\u041E\u0442\u043A\u0440\u044B\u0442\u044C");
		checkBox.setBounds(325, 60, 113, 25);
		frame.getContentPane().add(checkBox);

		JCheckBox checkBox_1 = new JCheckBox("\u0417\u0430\u043A\u0440\u044B\u0442\u044C");
		checkBox_1.setSelected(true);
		checkBox_1.setBounds(325, 90, 113, 25);
		frame.getContentPane().add(checkBox_1);

		textField_3 = new JTextField();
		textField_3.setEditable(false);
		textField_3.setText("\u041D\u043E\u0436");
		textField_3.setBounds(536, 28, 116, 22);
		frame.getContentPane().add(textField_3);
		textField_3.setColumns(10);

		JButton button = new JButton(
				"\u041F\u043E\u0447\u0438\u0441\u0442\u0438\u0442\u044C \u041A\u0430\u0440\u0442\u043E\u0448\u043A\u0443");
		button.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				if (potato == null) {
					JOptionPane.showMessageDialog(null, "Картошки то нет, что чистить?", "Ошибка логики",
							0, null);
					return;
				}
				if (potato.length == 0) {
					JOptionPane.showMessageDialog(null, "Картошки то нет, что чистить?", "Ошибка логики",
							0, null);
					return;
				}

				for (int i = 0; i < potato.length; i++) {
					knife.Clean_potato(potato[i]);
				}
				// button9.Enabled = true;
				JOptionPane.showMessageDialog(null, "Картошку  можно добавлять в кастрюлю", "Кухня", 0, null);
			}
		});
		button.setBounds(536, 66, 181, 25);
		frame.getContentPane().add(button);

		JButton button_1 = new JButton("\u041F\u043E\u0447\u0438\u0441\u0442\u0438\u0442\u044C \u041B\u0443\u043A");
		button_1.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (onion == null) {
					JOptionPane.showMessageDialog(null, "Лука то нет, что чистить?", "Ошибка логики", 0,
							null);
					return;
				}
				if (onion.length == 0) {
					JOptionPane.showMessageDialog(null, "Лука то нет, что чистить?", "Ошибка логики", 0,
							null);
					return;
				}

				for (int i = 0; i < onion.length; ++i) {
					knife.Clean_onion(onion[i]);
				}
				// button11.Enabled = true;
				JOptionPane.showMessageDialog(null, "Лук  можно добавлять в кастрюлю", "Кухня", 0, null);
			}
		});
		button_1.setBounds(536, 104, 181, 25);
		frame.getContentPane().add(button_1);

		JButton button_2 = new JButton(
				"\u041F\u043E\u0447\u0438\u0441\u0442\u0438\u0442\u044C \u041C\u043E\u0440\u043A\u043E\u0432\u044C");
		button_2.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (carrot == null) {
					JOptionPane.showMessageDialog(null, "Моркови то нет, что чистить?", "Ошибка логики",
							0, null);
					return;
				}
				if (carrot.length == 0) {
					JOptionPane.showMessageDialog(null, "Моркови то нет, что чистить?", "Ошибка логики",
							0, null);
					return;
				}

				for (int i = 0; i < carrot.length; ++i) {
					knife.Clean_carrots(carrot[i]);
				}
				// button12.Enabled = true;
				JOptionPane.showMessageDialog(null, "Морковь  можно добавлять в кастрюлю", "Кухня", 0, null);

			}
		});
		button_2.setBounds(536, 142, 181, 25);
		frame.getContentPane().add(button_2);

		JButton button_4 = new JButton(
				"\u041D\u0430\u0440\u0435\u0437\u0430\u0442\u044C \u041A\u0443\u0440\u0438\u0446\u0443");
		button_4.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				knife.Cutting_c(chicken);
				JOptionPane.showMessageDialog(null, "Курицу можно добавлять в кастрюлю", "Кухня", 0, null);
				// button10.Enabled = true;
			}
		});
		button_4.setBounds(536, 178, 181, 25);
		frame.getContentPane().add(button_4);

		textField_4 = new JTextField();
		textField_4.setEditable(false);
		textField_4.setText("\u041A\u0430\u0441\u0442\u0440\u044E\u043B\u044F");
		textField_4.setBounds(536, 229, 116, 22);
		frame.getContentPane().add(textField_4);
		textField_4.setColumns(10);

		JButton btnNewButton = new JButton(
				"\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C \u041A\u0430\u0440\u0442\u043E\u0448\u043A\u0443");
		btnNewButton.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (potato == null) {
					JOptionPane.showMessageDialog(null, "Картошки то нет, что варить?", "Ошибка логики",
							0, null);
					return;
				}
				if (potato.length == 0) {
					JOptionPane.showMessageDialog(null, "Картошки то нет, что варить?", "Ошибка логики",
							0, null);
					return;
				}
				for (int i = 0; i < potato.length; ++i) {

					if (potato[i].getHave_scin()) {
						JOptionPane.showMessageDialog(null, "Картошки надо почистить", "Ошибка логики",
								0, null);
						return;
					}
				}
				pan.AddPotato(potato);

				// buttonAddPan.Enabled = true;
				JOptionPane.showMessageDialog(null, "Картошку положили", "Кухня", 0, null);

			}
		});
		btnNewButton.setBounds(536, 272, 181, 25);
		frame.getContentPane().add(btnNewButton);

		JButton button_5 = new JButton("\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C \u041B\u0443\u043A");
		button_5.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (onion == null) {
					JOptionPane.showMessageDialog(null, "Лука то нет, что варить?", "Ошибка логики", 0,
							null);
					return;
				}
				if (onion.length == 0) {
					JOptionPane.showMessageDialog(null, "Лука то нет, что варить?", "Ошибка логики", 0,
							null);
					return;
				}
				for (int i = 0; i < onion.length; ++i) {

					if (onion[i].getHave_scin()) {
						JOptionPane.showMessageDialog(null, "Лук надо почистить", "Ошибка логики", 0,
								null);
						return;
					}
				}
				pan.AddOnion(onion);

				// buttonAddPan.Enabled = true;
				JOptionPane.showMessageDialog(null, "Лук положили", "Кухня", 0, null);
			}
		});
		button_5.setBounds(536, 308, 181, 25);
		frame.getContentPane().add(button_5);

		JButton button_6 = new JButton(
				"\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C \u041C\u043E\u0440\u043A\u043E\u0432\u044C");
		button_6.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (carrot == null) {
					JOptionPane.showMessageDialog(null, "Моркови то нет, что варить?", "Ошибка логики",
							0, null);
					return;
				}
				if (carrot.length == 0) {
					JOptionPane.showMessageDialog(null, "Моркови то нет, что варить?", "Ошибка логики",
							0, null);
					return;
				}
				for (int i = 0; i < carrot.length; ++i) {

					if (carrot[i].getHave_scin()) {
						JOptionPane.showMessageDialog(null, "Моркови надо почистить", "Ошибка логики",
								0, null);
						return;
					}
				}
				pan.AddCarrot(carrot);

				// buttonAddPan.Enabled = true;
				JOptionPane.showMessageDialog(null, "Морковь положили", "Кухня", 0, null);
			}
		});
		button_6.setBounds(536, 344, 181, 25);
		frame.getContentPane().add(button_6);

		JButton button_7 = new JButton(
				"\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C \u041B\u0430\u043F\u0448\u0443");
		button_7.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (lapsha == null) {
					JOptionPane.showMessageDialog(null, "Лапши то нет, что варить собрались?", "Ошибка логики",
							0, null);
					return;
				}

				JOptionPane.showMessageDialog(null, "Лапша в кастрюле", "Кухня", 0, null);
				pan.AddLapsha(lapsha);
			}
		});
		button_7.setBounds(536, 380, 181, 25);
		frame.getContentPane().add(button_7);

		JButton button_8 = new JButton(
				"\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C \u041A\u0443\u0440\u0438\u0446\u0443");
		button_8.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (chicken == null) {
					JOptionPane.showMessageDialog(null, "Курицы то нет, что варить собрались?", "Ошибка логики",
							0, null);
					return;
				}
				if (chicken.getcutting()) {
					JOptionPane.showMessageDialog(null, "Курицу нужно нарезать", "Ошибка логики", 0,
							null);
					return;
				}
				JOptionPane.showMessageDialog(null, "Курица в кастрюле", "Кухня", 0, null);
				pan.AddChicken(chicken);
			}
		});
		button_8.setBounds(536, 416, 181, 25);
		frame.getContentPane().add(button_8);

		JButton button_9 = new JButton("\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C \u0421\u043E\u043B\u044C");
		button_9.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
			}
		});
		button_9.setBounds(536, 452, 181, 25);
		frame.getContentPane().add(button_9);

		JButton button_10 = new JButton("\u0417\u0430\u043B\u0438\u0442\u044C \u0412\u043E\u0434\u0443");
		button_10.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (checkBox.isSelected() == true) {
					waterTap.setState(true);
					checkBox_1.setSelected(false);
				}
				if (!waterTap.getState()) {
					JOptionPane.showMessageDialog(null, "Воды нет", "Кухня", 0, null);
					return;
				}
				if(waterTap.getState()){
				pan.AddWater(waterTap.GetWater());
				checkBox_1.setSelected(true);
				checkBox.setSelected(false);
				// button13.Enabled = true;
				// radioButton2.Checked = true;
				JOptionPane.showMessageDialog(null, "Воду залили", "Кухня", 0, null);
				}

			}
		});
		button_10.setBounds(536, 488, 181, 25);
		frame.getContentPane().add(button_10);

		textField_5 = new JTextField();
		textField_5.setEditable(false);
		textField_5.setText("\u041F\u043B\u0438\u0442\u0430");
		textField_5.setBounds(28, 219, 116, 22);
		frame.getContentPane().add(textField_5);
		textField_5.setColumns(10);

		JCheckBox checkBox_2 = new JCheckBox("\u0412\u043A\u043B");
		checkBox_2.setBounds(28, 250, 113, 25);
		frame.getContentPane().add(checkBox_2);

		JButton button_11 = new JButton(
				"\u041F\u043E\u0441\u0442\u0430\u0432\u0438\u0442\u044C \u041A\u0430\u0441\u0442\u0440\u044E\u043B\u044E");
		button_11.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				stove.setPan(pan);
				JOptionPane.showMessageDialog(null, "Кастрюлька на плите", "Кухня", 0, null);
			}
		});
		button_11.setBounds(28, 284, 181, 25);
		frame.getContentPane().add(button_11);

		JButton button_12 = new JButton("\u0413\u043E\u0442\u043E\u0432\u0438\u0442\u044C");
		button_12.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				stove.setState(checkBox_2.isSelected());
				if (!stove.pan1()) {

					JOptionPane.showMessageDialog(null, "У нас не все готово к варке!", "Ошибка логики",
							0, null);
					return;
				}
				if (!stove.getState()) {
					JOptionPane.showMessageDialog(null, "Варить собрались энергией космоса или все же включим плиту?",
							"Ошибка логики", 0, null);
					return;
				}
				stove.Cook();
				if (!stove.getPan().Isready()) {
					checkBox_2.setSelected(false);
					JOptionPane.showMessageDialog(null, "ГОТОВО", "Кухня", 0, null);
				} else {
					JOptionPane.showMessageDialog(null, "Что-то пошло не так", "Ошибка логики", 0,
							null);
					return;

				}

			}
		});
		button_12.setBounds(29, 322, 180, 25);
		frame.getContentPane().add(button_12);
		
		JButton btnNewButton_1 = new JButton("\u041F\u043E\u043C\u044B\u0442\u044C \u041A\u0430\u0440\u0442\u043E\u0448\u043A\u0443 ");
		btnNewButton_1.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				if (checkBox.isSelected() == true) {
					waterTap.setState(true);
					checkBox_1.setSelected(false);
				}
				if (!waterTap.getState()) {
					JOptionPane.showMessageDialog(null, "Воды нет", "Кухня", 0, null);
					return;
				}
				
				 if (!waterTap.State)
		            {
					 JOptionPane.showMessageDialog(null,"Кран закрыт, как мыть?", "Ошибка логики",0,null);
		                return;
		            }
		           
		            else {
						for (int i = 0; i < potato.length; ++i)
						{
							potato[i] = new Potato();
						}
						for (int i = 0; i < potato.length; ++i)
						{
							potato[i].Dirty = false;
						}

					}


				 JOptionPane.showMessageDialog(null,"Картоху помыли", "Кухня", 0,null);
			}
		});
		btnNewButton_1.setBounds(306, 143, 164, 23);
		frame.getContentPane().add(btnNewButton_1);
		
		JButton btnNewButton_2 = new JButton("\u041F\u043E\u043C\u044B\u0442\u044C \u041C\u043E\u0440\u043A\u043E\u0432\u044C");
		btnNewButton_2.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				
				if (checkBox.isSelected() == true) {
					waterTap.setState(true);
					checkBox_1.setSelected(false);
				}
				if (!waterTap.getState()) {
					JOptionPane.showMessageDialog(null, "воды нет", "Кухня", 0, null);
					return;
				}
				
				 if (!waterTap.State)
		            {
					 JOptionPane.showMessageDialog(null,"Кран закрыт, как мыть?", "Ошибка логики",0,null);
		                return;
		            }
		           
		            else {
						for (int i = 0; i < carrot.length; ++i)
						{
							carrot[i] = new Carrot();
						}
						for (int i = 0; i < carrot.length; ++i)
						{
							carrot[i].Dirty = false;
						}

					}


				 JOptionPane.showMessageDialog(null,"Морковь помыли", "Кухня", 0,null);
			}
		});
		btnNewButton_2.setBounds(306, 179, 164, 23);
		frame.getContentPane().add(btnNewButton_2);
		
		JButton btnNewButton_3 = new JButton("\u041F\u043E\u043C\u044B\u0442\u044C \u041B\u0443\u043A");
		btnNewButton_3.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				
				if (checkBox.isSelected() == true) {
					waterTap.setState(true);
					checkBox_1.setSelected(false);
				}
				if (!waterTap.getState()) {
					JOptionPane.showMessageDialog(null, "воды нет", "Кухня", 0, null);
					return;
				}
				
				 if (!waterTap.State)
		            {
					 JOptionPane.showMessageDialog(null,"Кран закрыт, как мыть?", "Ошибка логики",0,null);
		                return;
		            }
		           
		            else {
						for (int i = 0; i < onion.length; ++i)
						{
							onion[i] = new Onion();
						}
						for (int i = 0; i < onion.length; ++i)
						{
							onion[i].Dirty = false;
						}

					}


				 JOptionPane.showMessageDialog(null,"Лук помыли", "Кухня", 0,null);
			}
		});
		btnNewButton_3.setBounds(306, 219, 164, 23);
		frame.getContentPane().add(btnNewButton_3);
	}
}
