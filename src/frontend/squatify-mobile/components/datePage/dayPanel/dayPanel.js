import { StyleSheet, View, Text } from 'react-native';
import { forgroundColor } from '../../../utils/colors';
import { vh } from '../../../utils/units';
import AccountTitle from './accountTitle';
import DateSelectButton from './dateSelectButton';
import DateTitle from './dateTitle';

export default function DayPanel() {
  return (
    <View style={styles.container}>
      <View style={styles.row}>
        <AccountTitle></AccountTitle>
        <DateSelectButton></DateSelectButton>
      </View>
      <DateTitle></DateTitle>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,

    backgroundColor: forgroundColor,
    paddingTop: 4 * vh,
    paddingBottom: 2 * vh,
    paddingLeft: 3 * vh,
    paddingRight: 3.5 * vh,

    borderBottomLeftRadius: 2 * vh,
    borderBottomRightRadius: 2 * vh
  },
  row: {
    flex: 1,
    flexDirection:'row',
    alignItems: 'center',
  }
});
