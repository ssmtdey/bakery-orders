namespace Bakery.Api.Models;

public enum Channel { Email, Instagram, Messenger }

public enum Flavour { Vanilla, Chocolate, RedVelvet }

public enum PaymentMethod { Cash, BankTransfer }

public enum OrderStatus
{
    AwaitingDetails, 
    Quoted, 
    Confirmed, 
    Declined, 
    InPreparation, 
    Ready,
    PickedUp, 
    Cancelled
}

public enum DeclineReason { TooComplex, FullyBooked, Other }

public enum Occasion
{
    Birthday, Wedding, Engagement, BridalShower, BabyShower, GenderReveal,
    Graduation, Anniversary, ReligiousCelebration, SeasonalDay, Corporate,
    Other
}