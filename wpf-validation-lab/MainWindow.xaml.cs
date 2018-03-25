using System;
using System.Collections.Generic;
using System.Linq;
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

namespace wpf_validation_lab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Model DC { get; set; }

        public MainWindow()
        {
            DC = new Model { PosInt1 = 21, PosInt2 = 7, PosInt3 = 23, PosInt4 = 3 };
            InitializeComponent();
        }

        private void tbx_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tbx = sender as TextBox;
            if (tbx != null)
            {
                BindingExpression be = tbx.GetBindingExpression(TextBox.TextProperty);
                be.UpdateTarget();
                Validation.ClearInvalid(be);
            }
        }

        private void tbx1_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                int i = int.Parse(tbx1.Text);
                DC.PosInt1 = i;
            }
            catch (Exception ex)
            {
                ValidationError validationError = new ValidationError(new ExceptionValidationRule(),
                    tbx1.GetBindingExpression(TextBox.TextProperty));

                validationError.ErrorContent = ex.Message;

                Validation.MarkInvalid(
                    tbx1.GetBindingExpression(TextBox.TextProperty),
                    validationError);
            }
        }

        private void tbx2_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tbx = sender as TextBox;
            try
            {
                tbx.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                while (ex2.InnerException != null)
                {
                    ex2 = ex2.InnerException;
                }

                ValidationError validationError = new ValidationError(new ExceptionValidationRule(),
                    tbx.GetBindingExpression(TextBox.TextProperty));

                validationError.ErrorContent = ex2.Message;

                Validation.MarkInvalid(
                    tbx.GetBindingExpression(TextBox.TextProperty),
                    validationError);
            }
        }

        private void tbx2_Error(object sender, ValidationErrorEventArgs e)
        {
            return;
        }

        public object onUpdateSourceException(object bindExpression, Exception exception)
        {
            var be = (System.Windows.Data.BindingExpression)bindExpression;
            var rule = be.ParentBinding.ValidationRules.First(x => x is ExceptionValidationRule);
            ValidationError ve = new ValidationError(rule, be, exception.GetType().Name, exception);
            return ve;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            throw new Exception("Thrown Exception");
        }

        private void ItemError(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                MessageBox.Show(e.Error.ErrorContent.ToString());
            }
        }

        private void tbx4_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {

            }
            return;
        }
    }
}
