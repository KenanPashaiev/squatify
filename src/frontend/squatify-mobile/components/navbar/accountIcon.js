import { StyleSheet, View } from 'react-native';
import AccountIconSvg from '../../assets/accountIcon';
import { iconSelectedColor, iconUnselectedColor } from '../../utils/colors';
import { vh } from '../../utils/units';

export default function AccountIcon(props) {
  return (
    <View style={styles.container}>
      <AccountIconSvg style={styles.logo} width={3.5*vh} height={3.5*vh} fill={props.focused?iconSelectedColor:iconUnselectedColor}></AccountIconSvg>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,

    alignItems: 'center',
    justifyContent: 'center',
  },

  
});
