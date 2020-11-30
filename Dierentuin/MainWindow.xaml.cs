using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using Dierentuin.Classes.Animals;
using Dierentuin.Classes;


namespace Dierentuin
{
    public partial class MainWindow : Window
    {
        readonly DispatcherTimer timer = new DispatcherTimer();
        readonly List<Animal> animalsInZoo = new List<Animal>();
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += Timer_Tick;
            // what data is shown in the listview
            AnimalList.ItemsSource = animalsInZoo;
        }

        #region Buttons to add animals
        private void MonkeyButton_Click(object sender, RoutedEventArgs e) => AddAnimalClick(new Monkey());

        private void ElephantButton_Click(object sender, RoutedEventArgs e) => AddAnimalClick(new Elephant());

        private void LionButton_Click(object sender, RoutedEventArgs e) => AddAnimalClick(new Lion());
        #endregion
        #region feeding buttons
        private void FeedAll(object sender, RoutedEventArgs e)
        {
            foreach (Animal animals in animalsInZoo)
            {
                animals.Eat();
                AnimalList.Items.Refresh();
            }
        }

        private void FeedLion_Click(object sender, RoutedEventArgs e) => AnimalFeedClick(typeof(Lion));

        private void FeedElephant_Click(object sender, RoutedEventArgs e) => AnimalFeedClick(typeof(Elephant));

        private void FeedMonkeyButton_Click(object sender, RoutedEventArgs e) => AnimalFeedClick(typeof(Monkey));

        #endregion
        #region utlities

        private void AddAnimalClick(Animal animal)
        {
            animal.Name = nickNameTextBox.Text;
            if (!animalsInZoo.Any(a => a.Name == nickNameTextBox.Text && a.GetType() == animal.GetType()))
            {
                animalsInZoo.Add(animal);
            }
            AnimalList.Items.Refresh();
        }

        private void AnimalFeedClick(Type someAnimal)
        {
            foreach (Animal a in animalsInZoo)
            {
                if (a.GetType() == someAnimal) a.Eat();
            }
            AnimalList.Items.Refresh();
        }

        // clearing nicknamebox so u can instantly start typing instead of removing dummy text
        private void ClearField(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (nickNameTextBox.Text == "Enter nickname")
            {
                nickNameTextBox.Text = null;
            }
        }

        // testing the UseEnergy method to see if all animals lose energy - need to make tick event
        private void UseEnergy_Click(object sender, RoutedEventArgs e)
        {
            foreach (Animal animal in animalsInZoo)
            {
                animal.UseEnergy();
                AnimalList.Items.Refresh();
            }

            foreach (Animal animal in animalsInZoo.ToList())
            {
                if (animal.Energy <= 0)
                {
                    animalsInZoo.Remove(animal);
                }
            }
        }
        #endregion
        #region tickevent
        void Timer_Tick(object sender, EventArgs e)
        {
            foreach (Animal animal in animalsInZoo)
            {
                animal.UseEnergy();
                AnimalList.Items.Refresh();
            }
            // create a copy of the collection and make new list to check every item;
            foreach (Animal animal in animalsInZoo.ToList())
            {
                if (animal.Energy <= 0)
                {
                    animalsInZoo.Remove(animal);
                }
            }

        }
        #endregion
        #region start/stop button for the tick evcent
        private void StartTimerButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void StopTimerButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }
        #endregion
    }
}