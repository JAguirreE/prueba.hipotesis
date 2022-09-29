namespace prueba.hipotesis
{
  public partial class MainMenu : Form
  {
    public MainMenu()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      Average avg = new(this);
      avg.Show();
    }

    private void button2_Click(object sender, EventArgs e)
    {

    }
  }
}