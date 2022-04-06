import { StyleSheet, View } from 'react-native';
import SortIconSvg from '../../../assets/sortIcon';
import { accentBackgroundColor } from '../../../utils/colors';
import { vh } from '../../../utils/units';

export default function SortButton() {
  return (
    <View style={styles.container}>
      <SortIconSvg style={styles.logo} width={3.4*vh} height={3.4*vh} fill={accentBackgroundColor}></SortIconSvg>
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
