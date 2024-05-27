using MVVMExamples.MVVM.Models;
using MVVMExamples.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;


namespace MVVMExamples.MVVM.ViewModels;


public class PeopleViewModel : INotifyPropertyChanged
{
    private ObservableCollection<Person> people;

    public ObservableCollection<Person> People
    {
        get => people;
        set
        {
            people = value;
            OnPropertyChanged(nameof(People));
        }
    }

    public ICommand LoadPeopleCommand { get; }

    public event PropertyChangedEventHandler PropertyChanged;

    public PeopleViewModel()
    {
        LoadPeopleCommand = new RelayCommand(_ => LoadPeople());
    }

    public void LoadPeople()
    {
        People = new ObservableCollection<Person>
        {
            new Person { Name = "Federico Mendoza", Age = 30 },
            new Person { Name = "Juana Chana", Age = 25 }
        };
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}


