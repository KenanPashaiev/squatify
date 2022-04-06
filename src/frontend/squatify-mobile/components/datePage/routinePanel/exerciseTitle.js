import { StyleSheet, View, Text } from 'react-native';
import { backgroundColor, defaultFontColor, secondaryFontColor } from '../../../utils/colors';
import { vh } from '../../../utils/units';

export default function ExerciseTitle(props) {
  return (
    <View style={styles.container}>
      <Text style={styles.name}>
        {props.exercise.name}
      </Text>
      {props.allEqual ?
        <Text style={styles.weight}>{props.exercise.sets[0].weight + ' kg'}</Text>
        : null
      }
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 2,
    alignItems: 'flex-end',
    flexDirection: 'row',

    marginBottom: 1 * vh,
  },
  name: {
    fontFamily: "Lufga-ExtraBold",
    fontSize: 2 * vh,
    color: defaultFontColor,
    marginRight: 1.5*vh,
  },
  weight: {

    fontFamily: "Lufga-Bold",
    fontSize: 1.8 * vh,
    color: secondaryFontColor,
  }
});
