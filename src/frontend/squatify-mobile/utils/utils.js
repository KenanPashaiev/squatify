import uuid from 'react-native-uuid';

export function combineIf(condition, defaultStyle, secondStyle) {
    return condition ? [defaultStyle, secondStyle] : defaultStyle;
}

export function sameDay(d1, d2) {
    return d1.getFullYear() === d2.getFullYear() &&
      d1.getMonth() === d2.getMonth() &&
      d1.getDate() === d2.getDate();
  }

export function getDaysArray(start, end) {
    var localStart = new Date(start);
    var localEnd = new Date(end);
    var i = 0;
    for (var arr = [], dt = new Date(localStart); dt <= localEnd; dt.setDate(dt.getDate() + 1)) {
        arr.push(
            {
                id: uuid.v4(),
                weekDay: getMonthName(dt),
                number: dt.getDate(),
                date: new Date(dt),
                index: i
            }
        );
        i++;
    }

    return arr;
};

const days = ['Sun','Mon','Tues','Wed','Thurs','Fri','Sat'];

function getDayName(date) {
    return days[date.getDay()];;
}

const moths = ['Jan','Feb','Mar','Apr','May','Jun','Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];

function getMonthName(date) {
    return moths[date.getMonth()];
}