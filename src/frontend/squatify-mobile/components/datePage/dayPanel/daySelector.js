import { React, useState, useEffect, useRef } from 'react';
import { SafeAreaView, View, FlatList, StyleSheet, Text, TouchableHighlight } from 'react-native';
import { accentBackgroundColor, accentFontColor, backgroundColor, defaultFontColor } from '../../../utils/colors';
import { vh } from '../../../utils/units';
import { combineIf, getDaysArray, sameDay } from '../../../utils/utils';

export default function DaySelector() {
  const [selectedDayId, setSelectedDayId] = useState(' ');
  const [index, setIndex] = useState(0);
  const [selectableDays, setSelectableDays] = useState(DATA);
  const ref = useRef(null);

  useEffect(() => {
    var now = new Date();
    var previousMonth = new Date(now);
    var nextMonth = new Date(now);
    previousMonth.setMonth(now.getMonth() - 1);
    nextMonth.setMonth(now.getMonth() + 1);
    var days = getDaysArray(previousMonth, nextMonth);
    setSelectableDays(days);

    var selectedDay = days.filter(d => sameDay(d.date, new Date()))[0];
    setSelectedDayId(selectedDay.id);
    setIndex(selectedDay.index);
    ref.current.scrollToIndex({
      index,
      animated: true
    })
  }, []);

  const renderItem = ({ item }) => (
    <View onTouchEndCapture={() => setSelectedDayId(item.id)}
      style={combineIf(item.id == selectedDayId, styles.day, styles.selectedDay)}>
      <Text style={combineIf(item.id == selectedDayId, styles.weekDay, styles.selectedText)}>
        {item.weekDay}
      </Text>
      <Text style={combineIf(item.id == selectedDayId, styles.number, styles.selectedText)}>
        {item.number}
      </Text>
    </View>
  );

  const listHeaderComponent = () => (
    <View style={{ width: 2 * vh }}>
    </View>
  );

  const itemSeparatorComponent = () => (
    <View style={{ width: 1.2 * vh }}>
    </View>
  );

  return (
    <SafeAreaView style={styles.container}>
      <FlatList
        ref={ref}
        contentContainerStyle={styles.list}
        initialScrollIndex={index}
        horizontal
        data={selectableDays}
        renderItem={renderItem}
        keyExtractor={item => item.id}
        showsVerticalScrollIndicator={false}
        showsHorizontalScrollIndicator={false}
        overScrollMode='never'
        ListHeaderComponent={listHeaderComponent}
        ItemSeparatorComponent={itemSeparatorComponent}
        ListFooterComponent={listHeaderComponent}
        onScrollToIndexFailed={(error) => {
          console.log(index);
          // setIndex(2);
        }}
      />
    </SafeAreaView>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 3,
  },
  list: {
    alignItems: 'center',
  },
  day: {
    backgroundColor: backgroundColor,
    borderRadius: 2 * vh,
    height: 10 * vh,
    width: 10 * vh,

    flexDirection: 'column',
    alignItems: 'center',
    justifyContent: 'center',
  },
  selectedDay: {
    backgroundColor: accentBackgroundColor,
  },
  weekDay: {
    color: defaultFontColor,
    fontFamily: "Lufga-Bold",
  },
  number: {
    color: defaultFontColor,
    fontFamily: "Lufga-ExtraBold",
    fontSize: 3.5 * vh
  },
  selectedText: {
    color: accentFontColor,
  },
});

// const DATA = [
//   {
//     id: 'bd7acbea-c1b1-46c2-aed5-3ad53abb28ba',
//     weekDay: 'Mon',
//     number: '22'
//   },
//   {
//     id: '3ac68afc-c605-48d3-a4f8-fbd91aa97f63',
//     weekDay: 'Tue',
//     number: '23'
//   },
//   {
//     id: '58694a0f-3da1-471f-bd96-145571e29d72',
//     weekDay: 'Wed',
//     number: '24'
//   },
//   {
//     id: '58624a0f-3da1-471f-bd96-145571e29d72',
//     weekDay: 'Thu',
//     number: '25'
//   },
//   {
//     id: '58624a0f-3da1-471f-bd96-145571e49d72',
//     weekDay: 'Fri',
//     number: '26'
//   },
// ];
