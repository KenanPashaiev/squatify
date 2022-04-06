import { StyleSheet, View, Text } from 'react-native';
import { defaultFontColor } from '../../../utils/colors';
import { vh } from '../../../utils/units';

export default function GalleryTitle() {
  return (
    <View style={styles.container}>
      <Text style={styles.weekDay}>
        Gallery
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

    fontFamily: "Lufga-ExtraBold",
    fontSize: 3 * vh,
    color: defaultFontColor,
  },
});
