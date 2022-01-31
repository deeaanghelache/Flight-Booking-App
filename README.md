# Flight Booking App

## __Andreea Anghelache, University of Bucharest__

## Project made using:
__ASP.NET__ (Backend) and __Angular__ (Frontend)

### __I. Database__

#### ___1. Entity-Relation Diagram___
![](/Images/DiagramaERD.png)

#### ___2. Describing the database___

#### __Entities__
- __Entities__ 
    - Passenger
    - Boarding Pass
    - Booking
    - Flight
    - Payment
    - Flight Info

- __Entities inherited from Microsoft Asp Net Core Identity__
    - User
    - User-Role
    - Role 

#### __Relations__
___1. One to Many___
- User and Passenger
- User and Booking
- Flight and Booking
- Flight and Flight Info

___2. One to One___
- Booking and Payment

___3. Many to Many___
- Booking and Passenger (the resulting diagram is Boarding Pass)


### __II. App__

#### ___Functionalities___

- __For Users__
    - Creating an account (Register)
    - Login
    - Booking flights
    - Register a passenger within your account
    - Displaying all the bookings in your account
    - Displaying all the passengers in your account
    - Deleting a booking
    - Deleting a passenger
- __For Admins__
    - Deleting a flight
    - Updating a flight
    - Adding a new flight
    - Updating a booking for a given user
    - Displaying all passengers
    - Get all Users

#### ___Forms___
- Add Booking Form

![](/Images/BookingFlight.png)

- Add Passenger Form

![](/Images/PassengerForm.png)

- Login Form

![](/Images/Login.png)

- Register Form

![](/Images/Register.png)

#### ___Other Pages___

- ___The page that displays all the bookings of the current user___

![](/Images/AllBookings.png)

- ___Profile Page___

![](/Images/profile.png)
