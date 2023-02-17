export class StringCalculator {

    add(numbers: string) {
        if (numbers === "") return 0;

        let delimeters = /\n|,/g;
        let n1 = numbers.split(delimeters);

        const result = n1.reduce((lhs, rhs) => lhs + parseInt(rhs, 10), 0);
        return result;
    }
}