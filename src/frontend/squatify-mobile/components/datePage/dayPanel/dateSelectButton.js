import { StyleSheet, View } from 'react-native';
import { vh } from '../../../utils/units';
import DateSelectIconSvg from '../../../assets/dateSelectIcon';
import { defaultFontColor } from '../../../utils/colors';

export default function DateSelectButton() {
  return (
    <View style={styles.container}>
      <DateSelectIconSvg style={styles.logo} width={4.5*vh} height={4.5*vh} fill={defaultFontColor}></DateSelectIconSvg>
    </View>
  );
}
const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  logo: {
    alignSelf:'flex-end',
  },
});
