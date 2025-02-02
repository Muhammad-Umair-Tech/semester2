import os

class Car:
    company = ""
    name = ""
    price = 0

    def __init__(self, company, name, price):
        self.name = name
        self.company = company
        self.price = price


    def compare(self, car, other_car):
        return car.company == other_car.company and car.name == other_car.name and car.price == other_car.price
        

def menu():
    os.system("cls")
    print("1. View cars")
    print("2. Add a car")
    print("3. Edit a car")
    print("4. Delete a car")
    print("5. Exit")
    choice = input("Choice (1-5): ")
    return choice


def view_cars(cars):
    for car in cars:
        print(f"Company: {car.company}\nName: {car.name}\nPrice: {car.price}\n")


def add_car():
    try:
        company = input("Company: ")
        name = input("Name: ")
        price = int(input("Price: "))
        car = Car(company, name, price)
        return car
    except ValueError:
        print("Invalid input.")


def edit_car(car):
    try:
        print("Editing: ")
        car.company = input("Enter company name: ")
        car.name = input("Enter car name: ")
        car.price = int(input("Enter price: "))
        return car
    except ValueError:
        print("Incorrect input.")


cars = []
car1 = Car("Suzuki", "Alto", 10000)
cars.append(car1)
while True:
    choice = menu()
    if choice == "1":
        view_cars(cars)
    elif choice == "2":
        cars.append(add_car())
    elif choice == "3": # edit a car
        try:
            car_found = False
            company_to_edit = input("Enter the company of the car to edit: ")
            name_to_edit = input("Enter the name of the car to edit: ")
            price_to_edit = int(input("Enter the price capacity of the car to edit (CC): "))
            car_to_edit = Car(company_to_edit, name_to_edit, price_to_edit)
            for car in cars:
                if car.compare(car, car_to_edit):
                    index = cars.index(car)
                    cars[index] = edit_car(car)
                    print("Successfully edited.")
                    car_found = True
                    break
            if car_found == False:
                print("No such car is available.")
        except ValueError:
            print("Incorrect input.")
    elif choice == "4": # delete a car
        try:
            car_found = False
            company_to_del = input("Enter the company of the car to delete: ")
            name_to_del = input("Enter the name of the car to delete: ")
            price_to_del = int(input("Enter the price capacity of the car to delete (CC): "))
            car_to_del = Car(company_to_del, name_to_del, price_to_del)
            for car in cars:
                if car.compare(car, car_to_del):
                    cars.remove(car)
                    print("Successfully deleted.")
                    car_found = True
                    break
            if car_found == False:
                print("No such car found.")
        except ValueError:
            print("Incorrect input.")
    elif choice == "5":
        break
    else:
        print("Incorrect input.")
    getch = input("Press any key to continue.")
    continue