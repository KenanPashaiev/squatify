import { FlatList, StyleSheet, View, SafeAreaView } from 'react-native';
import { vh } from '../../../utils/units';
import Exercise from './exercise';

export default function RoutinePanel() {
  const renderItem = ({ item }) => (
    <Exercise></Exercise>
  );

  const listHeaderComponent = () => (
    <View style={{ height: 2 * vh }}>
    </View>
  );

  const itemSeparatorComponent = () => (
    <View style={{ height: 2 * vh }}>
    </View>
  );

  return (
    <SafeAreaView style={styles.container}>
      <FlatList
        contentContainerStyle={styles.list}
        data={DATA}
        renderItem={renderItem}
        keyExtractor={item => item.id}
        showsVerticalScrollIndicator={false}
        showsHorizontalScrollIndicator={false}
        overScrollMode='never'
        ListHeaderComponent={listHeaderComponent}
        ItemSeparatorComponent={itemSeparatorComponent}
        ListFooterComponent={listHeaderComponent}
      >

      </FlatList>
    </SafeAreaView>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 6,

    paddingHorizontal: 2 *vh,
  },
  list: {
    alignItems: 'stretch',
  },
});


const DATA = [
  {
    id: 'bd7acbea-c1b1-46c2-aed5-3ad53abb28ba',
    weekDay: 'Mon',
    number: '22'
  },
  {
    id: 'bd7acbea-c1b2-46c2-aed5-3ad53abb28ba',
    weekDay: 'Mon',
    number: '22'
  },
  {
    id: 'bd7acbea-c1b3-46c2-aed5-3ad53abb28ba',
    weekDay: 'Mon',
    number: '22'
  }
];
