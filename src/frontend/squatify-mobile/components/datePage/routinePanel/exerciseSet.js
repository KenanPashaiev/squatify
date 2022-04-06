import { StyleSheet, View, Text, FlatList } from 'react-native';
import { accentBackgroundColor, accentFontColor, defaultFontColor, forgroundColor, secondaryFontColor } from '../../../utils/colors';
import { vh, vw } from '../../../utils/units';

export default function ExerciseSet(props) {


  return (
    <View style={styles.container}>
      <View style={styles.set}>
        <View style={styles.reps}>
          <Text style={styles.repTitle}>{props.set.repCount}</Text>
        </View>
        {
        props.allEqual ?
          null
          :
          <Text style={styles.setTitle}>{props.set.weight+' kg'}</Text>
        }
      </View>

    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    maxWidth: 8 * vh,

  },
  set: {
    flex: 1,
    minWidth: 3.6 * vh,
  },
  setTitle: {
    alignSelf: 'center',
    padding: 0.5 * vh,
    paddingLeft: 0,
    paddingBottom: 0,

    fontFamily: "Lufga-Bold",
    fontSize: 1.8 * vh,
    color: secondaryFontColor,
  },
  reps: {
    alignSelf: 'center',

    justifyContent: 'center',

    marginRight: 0.8 * vw,
    borderRadius: 0.5 * vh,
    width: 3 * vh,
    height: 4 * vh,
    backgroundColor: accentBackgroundColor,

  },
  repTitle: {
    alignSelf: 'center',
    padding: 0.5 * vh,

    fontFamily: "Lufga-Bold",
    fontSize: 2 * vh,
    color: accentFontColor,
  },

});


{/* 

const renderItem = () => (
    <View style={styles.rep}></View>
  );

  const itemSeparatorComponent = () => (
    <View style={{ height: 0.5 * vh }}>
    </View>
  );


<FlatList
        contentContainerStyle={styles.repContainer}
        data={[...Array(props.set.repCount).keys()]}
        renderItem={renderItem}
        keyExtractor={item => item}
        numColumns={5}
        showsVerticalScrollIndicator={false}
        showsHorizontalScrollIndicator={false}
        overScrollMode='never'
        ItemSeparatorComponent={itemSeparatorComponent}
      /> 
    
  repContainer: {
    flex: 1,

    flexDirection: 'column',
  },
  rep: {
    backgroundColor: accentBackgroundColor,
    borderRadius: 0.2 * vh,
    width: 1.2 * vh,
    height: 2 * vh,
    marginRight: 0.8 * vw,
  },*/}