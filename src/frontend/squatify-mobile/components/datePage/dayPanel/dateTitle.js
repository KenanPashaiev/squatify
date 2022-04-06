import { StyleSheet, View, Text } from 'react-native';
import { secondaryFontColor } from '../../../utils/colors';
import { vh } from '../../../utils/units';

export default function DateTitle() {
  return (
    <View style={styles.container}>
      <Text style={styles.weekDay}>
        Monday
      </Text>
      <Text style={styles.date}>
        April 4, 2022
      </Text>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 0.8,
    flexDirection: 'row',
    justifyContent: 'flex-end',
    alignItems: 'flex-end',
    alignContent: 'flex-end',
  },
  date: {
    flex: 1,
    fontFamily: "Lufga-Bold",
    fontSize: 2 * vh,
    color: secondaryFontColor,
    textAlign: 'right',
  },
  weekDay: {
    flex: 1,

    fontFamily: "Lufga-ExtraBold",
    fontSize: 3.5 * vh,
    color: '#000000',
    alignItems: 'flex-start',
    alignContent: 'flex-start',
    justifyContent: 'flex-start',
  },
});
