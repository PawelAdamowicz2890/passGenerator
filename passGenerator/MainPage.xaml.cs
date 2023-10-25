

namespace passGenerator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        Random CharSign = new Random();
        Random TypeSign = new Random();
        private char[][] Znaki =
        {
            new char[]{'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'},
            new char[]{'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'},
            new char[]{'1','2','3','4','5','6','7','8','9'},
            new char[]{'@','!','#','$','%','^','&','*','<','>','/','?','(',')'}
        };
        private void btnGenClicked(object sender, EventArgs e)
        {
            bool[] Types = new bool[4] { false, false, false, false };
            string wynik = "";
            if(chkMaleLitery.IsChecked)
            {
                Types[0] = true;
            }
            if (chkDuzeLitery.IsChecked)
            {
                Types[1] = true;
            }
            if (chkCyfry.IsChecked)
            {
                Types[2] = true;
            }
            if (chkZnakiSpec.IsChecked)
            {
                Types[3] = true;
            }
            if (!Types[0] && !Types[1] && !Types[2] && !Types[3] && DlugoscEnt.Text != "") { }
            else
            {
                hasloLbl.Text = wynik;
                int passLength;
                int TypeRand;
                int CharRand;
                bool czyLiczba=int.TryParse(DlugoscEnt.Text, out passLength);
                if(!czyLiczba || passLength<=0)
                {
                    hasloLbl.Text = "Długość musi być liczbą całkowitą dodatnią";
                    return;
                }
                for (int i = 0; i < passLength; i++)
                {
                    TypeRand = TypeSign.Next(0, 4);
                    if (Types[TypeRand])
                    {
                        CharRand = CharSign.Next(0, Znaki[TypeRand].Length);
                        wynik += Znaki[TypeRand][CharRand];
                    }
                    else
                        i--;
                }
                hasloLbl.Text = "Twoje hasło: "+wynik;
                SemanticScreenReader.Announce(hasloLbl.Text);
            }
           
            

        }
        
    }
}