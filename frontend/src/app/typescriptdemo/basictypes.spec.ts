describe('Declaring Variables in TypeScript', () => {

    describe('Explicity Typed Variables', () => {

        it('defining types', () => {
            let myName: string | number; // Union Type

            myName = "Jeff";

            expect(typeof myName).toEqual("string");

            expect(myName).toEqual("Jeff");

            myName = 1138;

            expect(typeof myName).toEqual("number");



            // expect(typeof myName).toEqual("function");
        });

        it('implicity defined types', () => {

            // when you initialize a type, it can infer the data type.
            let age = 53;
            let oldEnough = true;


            let name: string | number = 'Jeff';

            name = 'Sue';

            name = 1138;



        });

    });

    describe('custom types', () => {

        it('can use types', () => {
            // type alias

            type ThingWithLettersAndSTuff = string;

            let myName: ThingWithLettersAndSTuff = 'Bob';

            let beer: Product = {
                sku: 'beerz',
                qty: 6,
                price: 11.99,
                description: 'Stuff to drink'
            }

            let p2: SummaryProduct = {
                price: 8.99,
                description: 'Some Product'
            }
            let p3: SummaryProduct2 = {
                price: 8.99,
                description: 'Stuff',
                qty: 18
            }
        });

        it('can use interfaces', () => {
            let bob: Customer = {
                name: 'Robert',
                creditLimit: 3000,
                middleName: 'M'
            }
        });

        it('can use classes', () => {
            let thisClass = new Course('Intro to Programming', 10);

            expect(thisClass.numberOfDays).toEqual(10);
            expect(thisClass.title).toEqual('Intro to Programming');

            expect(thisClass.getInfo()).toEqual('This course is Intro to Programming and is 10 days long');

            let someClass: Course;

            someClass = {
                title: 'Some Title',
                numberOfDays: 18,
                getInfo: () => 'Long!'
            }
        });

    });

    describe('some literals', () => {

        it('string literals', () => {
            let name: string;

            name = "Jeff";
            expect(name).toEqual('Jeff');


            name = `Henry`;

            expect(name).toEqual('Henry');
            expect(name).toEqual("Henry");

            name = `
                you can do multline strings!

                Like this
            
            `;


            let age = 11;

            name = 'Henry';

            expect(`The name is ${name} and he is ${age} years old`).toEqual('The name is Henry and he is 11 years old');
        });

    });
});


type Product = {
    sku: string;
    price: number;
    qty: number;
    description?: string
}

type SummaryProduct = Pick<Product, 'price' | 'description'>;

type SummaryProduct2 = Omit<Product, 'sku'>;


interface Customer {
    name: string;
    creditLimit: number;
}

interface Customer {
    middleName: string;
}

class Course {
    // title: string; backing fields
    // numberOfDays: number;
    constructor(public title: string, public numberOfDays: number) { }

    getInfo() {
        return `This course is ${this.title} and is ${this.numberOfDays} days long`;
    }
}