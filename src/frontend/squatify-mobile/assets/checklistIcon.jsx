import Svg, { Path } from "react-native-svg"

const ChecklistIconSvg = (props) => (
    <Svg
        xmlns="http://www.w3.org/2000/svg"
        fill='none'
        viewBox="0 0 24 24"
        width={20} height={20}
        {...props}
    >
        <Path d="M2.808 3.087a.269.269 0 0 1 .269-.27h14.52a.269.269 0 0 1 .269.27v10.755a.807.807 0 0 0 1.613 0V3.087a1.882 1.882 0 0 0-1.882-1.882H3.077a1.882 1.882 0 0 0-1.883 1.882v17.747c0 1.039.844 1.882 1.883 1.882h7.529a.807.807 0 0 0 0-1.613h-7.53a.269.269 0 0 1-.268-.27V3.088z" />
        <Path d="M5.766 6.582a.807.807 0 0 0 0 1.614h9.142a.807.807 0 0 0 0-1.614H5.766zm-.807 5.11a.807.807 0 0 1 .807-.807h4.84a.807.807 0 0 1 0 1.613h-4.84a.807.807 0 0 1-.807-.807zm17.51 4.872a.807.807 0 1 0-1.14-1.14l-5.345 5.345-2.12-2.119a.807.807 0 1 0-1.14 1.14l2.69 2.69a.807.807 0 0 0 1.14 0l5.915-5.916z" />
    </Svg>

)

export default ChecklistIconSvg