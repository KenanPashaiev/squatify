import { StyleSheet, View, Text } from 'react-native';
import { defaultFontColor } from '../../../utils/colors';
import { vh } from '../../../utils/units';
import AvatarIcon from './avatarIcon';

export default function AccountTitle() {
  return (
    <View style={styles.container}>
      <AvatarIcon></AvatarIcon>

      <Text style={styles.weekDay}>
        itrisa
      </Text>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    flexDirection: 'row',
    alignItems: 'center',
  },
  weekDay: {
    flex: 1,
    paddingLeft: 1*vh,

    fontFamily: "Lufga-Bold",
    fontSize: 2.3 * vh,
    color: defaultFontColor,
  },
});
