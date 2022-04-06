import { useState } from 'react';
import { StyleSheet, View, TextInput } from 'react-native';
import FilterIconSvg from '../../../assets/filterIcon';
import { backgroundColor, searchBarBackgroundColor, secondaryInvertFontColor } from '../../../utils/colors';
import { vh } from '../../../utils/units';

export default function SearchBar() {
  const [value, setValue] = useState('');

  return (
    <View style={styles.container}>
      <TextInput style={styles.input}
          onChangeText={(text)=>setValue(text)}
          value={value}
          placeholder="Search"
          keyboardType="numeric"></TextInput>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 7,
  },
  input: {
    height: 40,
    borderWidth: 1,
    borderColor: searchBarBackgroundColor,
    backgroundColor: searchBarBackgroundColor,
    borderRadius: 1.75*vh,
    padding: 1*vh,
    paddingLeft: 1.75*vh,
    // backgroundColor: ,
    
  },
});
