import { StringCalculator } from "./string-calculator";

describe('String Calculator', () => {

    it('Empty String Returns Zero', () => {
        const calculator = new StringCalculator();

        let result = calculator.add("");

        expect(result).toEqual(0);
    });

    describe('single digits', () => {

        let calculator: StringCalculator;

        beforeEach(() => {
            calculator = new StringCalculator();
        });

        it('Example 1', () => {
            const result = calculator.add("1");
            expect(result).toEqual(1);
        })
        it('example 2', () => {
            const result = calculator.add("18");
            expect(result).toEqual(18);
        });
        it('Example 3', () => {
            const result = calculator.add("138");
            expect(result).toEqual(138);
        });
    });
    describe('two numbers', () => {
        let calculator: StringCalculator;

        beforeEach(() => {
            calculator = new StringCalculator();
        })
        it('first example', () => {

            let result = calculator.add("1,2");

            expect(result).toEqual(3);
        });
        it('Second Example', () => {
            let result = calculator.add("108, 2");
            expect(result).toEqual(110);
        });
        it('third example', () => {
            let result = calculator.add('1,30008');
            expect(result).toEqual(30009);
        });

    });
    describe('mixed delimeters', () => {

        let calculator: StringCalculator;

        beforeEach(() => {
            calculator = new StringCalculator();
        })

        it('can use newlines', () => {
            let result = calculator.add("1\n2");

            expect(result).toEqual(3);
        });
        it('can use both', () => {
            let result = calculator.add("1\n2,3");
            expect(result).toEqual(6);
        })
    });
});