import { StyleSheet, View } from 'react-native';
import FilterIconSvg from '../../../assets/filterIcon';
import { accentBackgroundColor, defaultFontColor } from '../../../utils/colors';
import { vh } from '../../../utils/units';

export default function FilterButton() {
  return (
    <View style={styles.container}>
      <FilterIconSvg style={styles.logo} width={3*vh} height={3*vh} fill={accentBackgroundColor}></FilterIconSvg>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  logo: {
    alignSelf:'flex-start',
  },
});
