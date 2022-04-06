import { StyleSheet, View, Text } from 'react-native';
// import HomeIcon from '../../assets/homeIcon';
import StatsIcon from '../../assets/statsIcon';
import { vh } from '../../utils/units';
import AccountIcon from './accountIcon';
import CalendarIcon from './calendarIcon';
import CheckListIcon from './checkListIcon';
import HomeIcon from './homeIcon';

export default function Navbar() {
  return (
    <View style={styles.container}>
      <HomeIcon></HomeIcon>
      <CheckListIcon></CheckListIcon>
      <CalendarIcon></CalendarIcon>
      <AccountIcon></AccountIcon>
    </View>
  );
}
const styles = StyleSheet.create({
  container: {
    flex: 1,
    paddingHorizontal: 2 * vh,
    flexDirection: 'row',

    backgroundColor: '#ffffff',
    // borderTopLeftRadius: 2*vh,
    // borderTopRightRadius: 2*vh
  },
});
