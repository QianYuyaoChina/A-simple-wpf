using System.ComponentModel;
using System.Security.RightsManagement;
using System.Windows.Media;

namespace MCPE_GUI
{
    public class Game : INotifyPropertyChanged
    {
        private string _gamename;
        private string _id;
        private string _count;
        private bool _isCurrentGame;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Gamename
        {
            get => _gamename;
            set
            {
                _gamename = value;
                OnPropertyChanged(nameof(Gamename));
            }
        }
        public string Count
        {
            get => _count;
            set
            {
                _count = value;
                OnPropertyChanged(nameof(Count));
            }
        }
        public string Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public bool IsCurrentGame
        {
            get => _isCurrentGame;
            set
            {
                _isCurrentGame = value;
                OnPropertyChanged(nameof(IsCurrentGame));
                OnPropertyChanged(nameof(RowBackground));
            }
        }
        public Brush RowBackground
        {
            get
            {
                if (IsCurrentGame) return new SolidColorBrush(Color.FromArgb(30, 30, 144, 255)); // 浅蓝色背景
                return Brushes.Transparent;
            }
        }
        private string calcCount()
        {
            return "0";
        }
        private string calcName()
        {
            return "NULL";
        }
        public Game(string id)
        {
            Id = id;
            Gamename = calcName();
            Count = calcCount();
            IsCurrentGame = false;
        }

        public void SetAsCurrentGame()
        {
            IsCurrentGame = true;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public bool JoinGame()
        {
            return true; // 模拟加入游戏的逻辑
        }
    }
}