import Svg, { Path } from "react-native-svg";

function FilterIconSvg(props) {
  return (
    <Svg
      xmlns="http://www.w3.org/2000/svg"
      viewBox="0 0 50 50"
      fill='none'
      width={20} height={20}
      {...props}
    >
      <Path d="M4 2c-.6 0-1 .4-1 1v3c0 .3.112.487.313.688l16 17c.2.2.487.312.687.312h10c.3 0 .488-.113.688-.313l16-17c.2-.2.312-.387.312-.687V3c0-.6-.4-1-1-1H4zm15 24v15c0 .4.2.706.5.906l10 6c.1.1.3.094.5.094s.3.006.5-.094c.3-.2.5-.506.5-.906V26H19z"></Path>
    </Svg>
  );
}

export default FilterIconSvg;
