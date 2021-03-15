// Cars.cs
// Author: Willem Vidler
// Date: March 14th 2021
// Description: A class designed as a record of an individual car including information
using System;
using System.Collections.Generic;
using System.Text;

namespace CarInventory2._0
{
    class Cars
    {
        // Static private variable to hold the number of cars.
        private static int carCount = 0;
        // Private variable to hold the car's identification number.
        private int carId = 0;
        // Private variable to convert the ID number into a string
        private string carID = String.Empty;
        // Private variable to hold the car's make.
        private string carMake = String.Empty;
        // Private variable to hold the car's model.
        private string carModel = String.Empty;
        // Private variable to hold the car's year.
        private string carYear = String.Empty;
        // Private variable to hold the car's price.
        private string carPrice = String.Empty;
        // Private variable to hold the car's status.
        private bool carNewStatus = false;

        public Cars()
        {
            carCount += 1;
            carId = carCount;
          
        }

        public Cars(string ID, string make, string model, string year, string price, bool newStatus) : this()
        {
            // The ": this()" part above calls the default constructor, setting the Id.

            // Set all of the instance variables within this class using the values
            // passed into this constructor.
            carID = ID;
            carMake = make;
            carModel = model;
            carYear = year;
            carPrice = price;
            carNewStatus = newStatus;
        }

        public int ID
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }

        public bool NewStatus
        {
            get
            {
                return carNewStatus;
            }
            set
            {
                // The value passed in is always called "value" by default.
                carNewStatus = value;
            }
        }

        public string Make
        {
            get
            {
                return carMake;
            }
            set
            {
                carMake = value;
            }
        }

        public string Model
        {
            get
            {
                return carModel;
            }
            set
            {
                carModel = value;
            }
        }

        public string Year
        {
            get
            {
                return carYear;
            }
            set
            {
                carYear = value;
            }
        }

        public string Price
        {
            get
            {
                return carPrice;
            }
            set
            {
                carPrice = value;
            }
        }

    }
}
