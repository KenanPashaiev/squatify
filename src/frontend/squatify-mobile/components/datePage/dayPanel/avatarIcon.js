import { StyleSheet, View } from 'react-native';
import AvatarIconSvg from '../../../assets/avatarIcon';
import { useState } from 'react';
import { accentBackgroundColor, iconSelectedColor, iconUnselectedColor } from '../../../utils/colors';
import { vh } from '../../../utils/units';
import { backgroundColor } from 'react-native/Libraries/Components/View/ReactNativeStyleAttributes';

export default function AvatarIcon() {
  return (
    <View style={styles.container}>
      <AvatarIconSvg style={styles.logo} width={5 * vh} height={5 * vh}></AvatarIconSvg>
    </View>
  );
}
const styles = StyleSheet.create({
  container: {
    // flex: 1,

    alignItems: 'stretch',
    alignContent: 'stretch',
  },
  logo: {
    flex: 1,
    borderColor: accentBackgroundColor,
    borderWidth: 2,
    borderRadius: 1.2*vh,
    overflow: 'hidden',


    alignItems: 'center',
    alignContent: 'center',
    justifyContent: 'center',
  },
});
