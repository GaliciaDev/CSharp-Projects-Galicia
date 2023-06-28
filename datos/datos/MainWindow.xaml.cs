using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace datos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;
            if (string.IsNullOrEmpty(username) ||
            string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, ingresa un nombre de usuario y una contraseña.");
            return;
            }
            using (SqlConnection connection = new
            SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = G:\\GUI C# learning projects\\datos\\datos\\DATABASE1.MDF; Integrated Security = True; Connect Timeout = 30"))
        {
                string query = "INSERT INTO usuarios (username, password) VALUES(@Username, @Password)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Registro exitoso.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar: " + ex.Message);
                }
            }
        }
        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;
            if (string.IsNullOrEmpty(username) ||
            string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, ingresa un nombre de usuario y una contraseña.");
            return;
            }
            using (SqlConnection connection = new
            SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = G:\\GUI C# learning projects\\datos\\datos\\DATABASE1.MDF; Integrated Security = True; Connect Timeout = 30"))
        {
                string query = " Delete From usuarios Where username=@Username and password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Delete exitoso.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al Eliminar: " + ex.Message);
                }
            }


        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;
            if (string.IsNullOrEmpty(username) ||
            string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, ingresa un nombre de usuario y una contraseña.");
            return;
            }
            using (SqlConnection connection = new
            SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = G:\\GUI C# learning projects\\datos\\datos\\DATABASE1.MDF; Integrated Security = True; Connect Timeout = 30"))
        {
                string query = "SELECT COUNT(*) FROM usuarios WHERE username = @Username AND password = @Password";SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Inicio de sesión exitoso.");
                        // Aquí puedes navegar a la ventana principal de tu
                    }
                    else
                    {
                        MessageBox.Show("Nombre de usuario o contraseña incorrectos.");
                     }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al iniciar sesión: " + ex.Message);
                }
            }
        }
    }
}