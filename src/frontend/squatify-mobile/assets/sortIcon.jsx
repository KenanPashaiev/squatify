import Svg, { Path } from "react-native-svg";

function SortIconSvg(props) {
    return (
        <Svg
            xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"
            fill='none'
            width={20} height={20}
            {...props}
        >
            <Path d="M1 2c-.551 0-1 .448-1 1v1.033c0 .551.449 1 1 1h22.038c.551 0 1-.449 1-1V3c0-.552-.449-1-1-1H1zm4.012 6c-.551 0-1 .448-1 1l-.017.984c0 .551.449 1 1 1h14.017c.551 0 1-.449 1-1L20.029 9c0-.552-.449-1-1-1H5.012zm2.989 6c-.551 0-1 .448-1 1v1.017c0 .551.449 1 1 1h8.022c.551 0 1-.449 1-1V15c0-.552-.449-1-1-1H8.001z"></Path>
        </Svg>
    );
}

export default SortIconSvg;
