import java.awt.Color;
import java.awt.EventQueue;
import java.awt.Graphics;

import javax.swing.JFrame;
import javax.swing.JTextField;
import javax.swing.JTextArea;
import javax.swing.JButton;
import javax.swing.JColorChooser;

import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;
import javax.swing.JPanel;
import java.awt.SystemColor;
import javax.swing.JCheckBox;

public class Form {

	private JFrame frame;
	private JTextField textField;
	private JTextField textField_1;
	private JTextArea textArea;
	private JTextArea textArea_1;
	private JTextArea textArea_2;
	private JTextArea textArea_3;
	private Color color;
	private Color dopColor;
	int maxSpeed;
	double Weigth;
	int maxCountPass;
	int vodoizmeshenie;
	private ITransport transport;
	private JTextField txtMaxcountpass;
	private JTextField textField_2;

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
		initialize();
		color = Color.GREEN;
		dopColor = Color.BLACK;
		maxSpeed = 150;
		Weigth = 1500;
		vodoizmeshenie = 300;
		maxCountPass = 7;

		textArea_1.setText("" + maxSpeed);
		textArea.setText("" + Weigth);
		textArea_2.setText("" + maxCountPass);
		textArea_3.setText("" + vodoizmeshenie);
		
		txtMaxcountpass = new JTextField();
		txtMaxcountpass.setText("maxCountPass");
		txtMaxcountpass.setBounds(12, 475, 116, 22);
		frame.getContentPane().add(txtMaxcountpass);
		txtMaxcountpass.setColumns(10);
		
		textField_2 = new JTextField();
		textField_2.setText("\u0412\u043E\u0434\u043E\u0438\u0437\u043C\u0435\u0449\u0435\u043D\u0438\u0435");
		textField_2.setColumns(10);
		textField_2.setBounds(12, 446, 116, 22);
		frame.getContentPane().add(textField_2);

	}

	/**
	 * Initialize the contents of the frame.
	 */
	private void initialize() {
		frame = new JFrame();
		frame.getContentPane().setBackground(Color.LIGHT_GRAY);
		frame.setBounds(100, 100, 836, 706);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.getContentPane().setLayout(null);

		textField = new JTextField();
		textField.setText("\u0412\u0435\u0441");
		textField.setBounds(12, 499, 116, 22);
		frame.getContentPane().add(textField);
		textField.setColumns(10);

		textField_1 = new JTextField();
		textField_1.setText("\u0421\u043A\u043E\u0440\u043E\u0441\u0442\u044C");
		textField_1.setBounds(12, 534, 116, 22);
		frame.getContentPane().add(textField_1);
		textField_1.setColumns(10);

		textArea = new JTextArea();
		textArea.setBounds(138, 503, 67, 22);
		frame.getContentPane().add(textArea);

		textArea_1 = new JTextArea();
		textArea_1.setBounds(138, 538, 67, 22);
		frame.getContentPane().add(textArea_1);

		textArea_2 = new JTextArea();
		textArea_2.setBounds(138, 475, 67, 22);
		frame.getContentPane().add(textArea_2);

		textArea_3 = new JTextArea();
		textArea_3.setBounds(138, 451, 67, 16);
		frame.getContentPane().add(textArea_3);

		JButton button = new JButton(
				"Лодка");
		button.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				transport = new Lodka(maxSpeed, maxCountPass, Weigth,
						vodoizmeshenie, color);
				Weigth = Double.parseDouble(textArea.getText());
				maxSpeed = Integer.parseInt(textArea_1.getText());
				maxCountPass = Integer.parseInt(textArea_2.getText());
				vodoizmeshenie = Integer.parseInt(textArea_3.getText());
				JPanel panel = new Ris(transport);
				panel.setBounds(12, 13, 700, 420);
				frame.getContentPane().add(panel);
				panel.updateUI();

			}
		});
		button.setBounds(12, 581, 147, 44);
		frame.getContentPane().add(button);

		JButton button_1 = new JButton(
				"Катер");
		button_1.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				transport = new Cutter(maxSpeed, maxCountPass, Weigth,
						vodoizmeshenie, color, true, dopColor);
				Weigth = Double.parseDouble(textArea.getText());
				maxSpeed = Integer.parseInt(textArea_1.getText());
				maxCountPass = Integer.parseInt(textArea_2.getText());
				vodoizmeshenie = Integer.parseInt(textArea_3.getText());
				JPanel panel = new Ris(transport);
				panel.setBounds(12, 13, 700, 420);
				frame.getContentPane().add(panel);
				panel.updateUI();
			}
		});
		button_1.setBounds(171, 581, 221, 44);
		frame.getContentPane().add(button_1);

		JButton button_2 = new JButton(
				"цвет лодки");
		button_2.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
			
				color = JColorChooser.showDialog(button_2, "цвет", color);

			}
		});
		button_2.setBounds(276, 498, 176, 25);
		frame.getContentPane().add(button_2);

		JButton button_3 = new JButton(
				"цвет катера");
		button_3.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				dopColor = JColorChooser.showDialog(button_2, "цвет", dopColor);
			}
		});
		button_3.setBounds(276, 533, 176, 25);
		frame.getContentPane().add(button_3);

		JPanel panel = new JPanel();
		panel.setBounds(12, 13, 700, 420);
		frame.getContentPane().add(panel);

	}
}