import { StyleSheet, View, FlatList } from 'react-native';
import { forgroundColor } from '../../../utils/colors';
import { vh } from '../../../utils/units';
import ExerciseSet from './exerciseSet';
import ExerciseTitle from './exerciseTitle';

export default function Exercise() {
  const allEqual = DATA.sets.every( (val, i, arr) => val.weight === arr[0].weight )

  const renderItem = ({ item }) => (
    <ExerciseSet set={item} allEqual={allEqual}></ExerciseSet>
  );

  const listHeaderComponent = () => (
    <View style={{ width: 2 * vh }}>
    </View>
  );

  const itemSeparatorComponent = () => (
    <View style={{ width: 1.2 * vh }}>
    </View>
  );

  return (
    <View style={styles.container}>
      <ExerciseTitle exercise={DATA} allEqual={allEqual}></ExerciseTitle>
      <FlatList
        contentContainerStyle={styles.list}
        horizontal
        data={DATA.sets}
        renderItem={renderItem}
        keyExtractor={item => item.id}
        showsVerticalScrollIndicator={false}
        showsHorizontalScrollIndicator={false}
        overScrollMode='never'
        ItemSeparatorComponent={itemSeparatorComponent}
      />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,

    backgroundColor: forgroundColor,
    borderRadius: 2 * vh,
    padding: 1.5 * vh,
  },
});

const DATA = {
  name: "Squat",
  duration: 15, 
  sets: [
    {
      id: 1,
      repCount: 5,
      weight: 125,
    },
    {
      id: 2,
      repCount: 6,
      weight: 125,
    },
    {
      id: 3,
      repCount: 7,
      weight: 125,
    },
    {
      id: 4,
      repCount: 6,
      weight: 125,
    },
  ]
}
